using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Plugin.AudioRecorder;
using Xamarin.Cognitive.BingSpeech;
using Plugin.TextToSpeech;

namespace B4.EE.OmedMilat.Domain.Services
{
    public class BingSpeechService
    {
        string BingSpeechApiKey = "ede4874dde25467d93ceb8ff46bb48f2";
        string SpeechResult = null;
        AudioRecorderService recorder;
        BingSpeechApiClient bingSpeechClient;

        public BingSpeechService()
        {
            recorder = new AudioRecorderService
            {
                StopRecordingOnSilence = true,
                StopRecordingAfterTimeout = true,
                TotalAudioTimeout = TimeSpan.FromSeconds(15)
            };

            bingSpeechClient = new BingSpeechApiClient(BingSpeechApiKey);

            Task.Run(() => bingSpeechClient.Authenticate());
        }

        public async Task RecordAudio()
        {
            try
            {
                if (!recorder.IsRecording) //Record button clicked
                {
                    //start recording audio
                    var audioRecordTask = await recorder.StartRecording();

                    //set the selected recognition mode & profanity mode
                    bingSpeechClient.RecognitionMode = RecognitionMode.Interactive;
                    bingSpeechClient.ProfanityMode = ProfanityMode.Raw;

                    var audioFile = await audioRecordTask;

                    //if we're not streaming the audio as we're recording, we'll use the file-based STT API here
                    if (audioFile != null)
                    {
                        var resultText = await SpeechToText(audioFile);
                        //ResultsLabel.Text = resultText ?? "No Results!";
                    }
                }

                else //Stop button clicked
                {
                    //stop the recording...
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

            Debug.WriteLine(SpeechResult);

            return SpeechResult;
        }

        public async Task test()
        {

            await CrossTextToSpeech.Current.Speak(SpeechResult);
        }
    }
}