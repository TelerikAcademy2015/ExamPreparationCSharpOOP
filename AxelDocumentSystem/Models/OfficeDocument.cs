namespace DocumentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using DocumentSystem.Interfaces;

    public abstract class OfficeDocument: EncriptableDocument, IDocument, IEncryptable
    {
        public OfficeDocument(string name, string content = null, long size = 0, string version = null)
            :base(name, content, size)
        {
            this.Version = version;
        }

        public string Version { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            key = key.ToLower();
            if (key == "version")
            {
                this.Version = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, object>> output)
        {
            if (this.Version != null)
            {
                output.Add(new KeyValuePair<string, object>("version", this.Version));
            }
            base.SaveAllProperties(output);
        }
    }
}
