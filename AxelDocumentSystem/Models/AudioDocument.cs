﻿namespace DocumentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using DocumentSystem.Interfaces;

    public class AudioDocument : MultimediaDocument, IDocument
    {
        public AudioDocument(string name, string content = null, int size = 0, long lenght = 0, double sampleRate = 0.0)
            : base(name, content, size, lenght)
        {
            this.SampleRate = sampleRate;
        }

        public double SampleRate { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            key = key.ToLower();
            if (key == "samplerate")
            {
                this.SampleRate = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, object>> output)
        {
            if (this.SampleRate != 0)
            {
                output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
            }
            base.SaveAllProperties(output);
        }
    }
}
