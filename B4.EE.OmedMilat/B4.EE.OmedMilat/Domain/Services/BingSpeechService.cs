﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Plugin.AudioRecorder;
using Xamarin.Cognitive.BingSpeech;
using Acr.UserDialogs;

namespace B4.EE.OmedMilat.Domain.Services
{
    public class BingSpeechService
    {
        static string SpeechResult = null;
        AudioRecorderService recorder;
        BingSpeechApiClient bingSpeechClient;
        ToastConfig Toast;

        public BingSpeechService()
        {
            recorder = new AudioRecorderService
            {
                StopRecordingOnSilence = true,
                StopRecordingAfterTimeout = true,
                TotalAudioTimeout = TimeSpan.FromSeconds(15)
            };

            bingSpeechClient = new BingSpeechApiClient(ApiConstants.BingSpeechApiKey);

            Task.Run(() => bingSpeechClient.Authenticate());
        }

        public async Task StopRecording()
        {
            await recorder.StopRecording();
        }

        public async Task RecordAudio()
        {
            try
            {
                if (!recorder.IsRecording) 
                {
                    var audioRecordTask = await recorder.StartRecording();

                    bingSpeechClient.RecognitionMode = RecognitionMode.Interactive;
                    bingSpeechClient.ProfanityMode = ProfanityMode.Raw;

                    var audioFile = await audioRecordTask; 

                    if (audioFile != null)
                    {
                        var resultText = await SpeechToText(audioFile);
                    }
                }

                else 
                {
                    SpeechResult = null;
                    await recorder.StopRecording();
                }
            }
            catch (Exception ex)
            {
                //blow up the app!
                throw ex;
            }
        }
        async Task<string> SpeechToText(string audioFile)
        {
            try
            {
                var detailedResult = await bingSpeechClient.SpeechToTextDetailed(audioFile);

                return ProcessResult(detailedResult);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        public string ProcessResult(RecognitionResult recognitionResult)
        {
            if (recognitionResult != null && recognitionResult.Results.Any())
            {
                var speechResult = recognitionResult.Results.First();

                SpeechResult = speechResult.Lexical;
            }
            Toast = new ToastConfig(SpeechResult);
            Toast.SetDuration(2000);
            Toast.SetBackgroundColor(System.Drawing.Color.Black);
            Toast.SetMessageTextColor(System.Drawing.Color.White);
            UserDialogs.Instance.Toast(Toast);
            Debug.WriteLine(SpeechResult);

            return SpeechResult;
        }

        public static string Result()
        {
             return SpeechResult;
        }
    }
}