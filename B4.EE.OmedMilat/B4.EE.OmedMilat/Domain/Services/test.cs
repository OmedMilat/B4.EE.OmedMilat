using System;
using System.Diagnostics;
using Microsoft.CognitiveServices.SpeechRecognition;

namespace B4.EE.OmedMilat.Domain.Services
{
    public class test
    {
        private MicrophoneRecognitionClient micClient;

        public void Start()
        {
            CreateMicrophoneRecoClient();
            micClient.StartMicAndRecognition();
        }
        private void CreateMicrophoneRecoClient()
        {
            this.micClient = SpeechRecognitionServiceFactory.CreateMicrophoneClient(
                this.Mode,
                this.DefaultLocale,
                this.SubscriptionKey);
            this.micClient.AuthenticationUri = this.AuthenticationUri;

            // Event handlers for speech recognition results

            this.micClient.OnResponseReceived += MicClient_OnResponseReceived;

        }

        private void MicClient_OnResponseReceived(object sender, SpeechResponseEventArgs e)
        {
            this.WriteLine("--- OnMicDictationResponseReceivedHandler ---");
            if (e.PhraseResponse.RecognitionStatus == RecognitionStatus.EndOfDictation ||
                e.PhraseResponse.RecognitionStatus == RecognitionStatus.DictationEndSilenceTimeout)
            {
                Dispatcher.Invoke(
                    (Action)(() =>
                    {
                        // we got the final result, so it we can end the mic reco.  No need to do this
                        // for dataReco, since we already called endAudio() on it as soon as we were done
                        // sending all the data.
                        this.micClient.EndMicAndRecognition();

                        this._startButton.IsEnabled = true;
                        this._radioGroup.IsEnabled = true;
                    }));
            }

            Debug.WriteLine(e);
        }
    }
}
