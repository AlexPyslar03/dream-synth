﻿using OxyPlot;
using System.Windows;
using NAudio.Wave;

namespace DreamSynth
{
    public partial class MainWindow : Window
    {
        public static WaveOutEvent waveOut;
        private AudioVisualizer audioVisualizer;

        public MainWindow()
        {
            InitializeComponent();
            InitializeAudioVisualizer();
            
            waveOut = new WaveOutEvent();
            waveOut.Init(WaveGeneratorControl.WaveGenerator);

            WaveGeneratorControl.WaveGenerator.OnSampleGenerated += samples =>
            {
                audioVisualizer.Update(samples);
            };
        }

        private void InitializeAudioVisualizer()
        {
            var plotModel = new PlotModel { Title = "Audio Signal" };
            audioVisualizer = new AudioVisualizer(plotModel);
            plotView.Model = plotModel;
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            waveOut.Play();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            waveOut.Stop();
        }
    }
}