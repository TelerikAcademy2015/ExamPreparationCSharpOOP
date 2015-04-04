namespace DocumentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using DocumentSystem.Interfaces;

    public class WordDocument : OfficeDocument, IDocument, IEncryptable
    {
        public WordDocument(string name, string content = null, long size = 0, string version = null, long numberOfCharacters = 0)
            : base(name, content, size, version)
        {
            this.NumberOfCharacters = numberOfCharacters;
        }

        public long NumberOfCharacters { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            key = key.ToLower();
            if (key == "chars")
            {
                this.NumberOfCharacters = long.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, object>> output)
        {
            if (this.NumberOfCharacters != 0)
            {
                output.Add(new KeyValuePair<string, object>("chars", this.NumberOfCharacters));
            }
            base.SaveAllProperties(output);
        }
    }
}
