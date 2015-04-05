namespace DocumentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using DocumentSystem.Interfaces;

    public class VideoDocument: MultimediaDocument, IDocument
    {
        public VideoDocument(string name, string content = null, int size = 0, long lenght = 0, long frameRate = 0)
            :base(name, content, size, lenght)
        {
            this.FrameRate = frameRate;
        }

        public long FrameRate { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            key = key.ToLower();
            if (key == "framerate")
            {
                this.FrameRate = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, object>> output)
        {
            if (this.FrameRate != 0)
            {
                output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));
            }
            base.SaveAllProperties(output);
        }
    }
}
