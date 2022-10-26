using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dictionaryapp
{
    internal class DictionaryResponseModel
    {
        public string Word { get; set; }
        public string Phonetic { get; set; }
        public Phonetic[] Phonetics { get; set; }
        public string Origin { get; set; }       
        public Meaning[] Meanings { get; set; }
    }

    public class Phonetic
    {
        public string Text { get; set; }
        public string Audio { get; set; }

    }

    public class Meaning
    {
        public string PartOfSpeech { get; set; }
        public DefinitionModel[] Definitions { get; set; }
    }

    public class DefinitionModel
    {
        public string Definition { get; set; }
        public string Example { get; set; }
        public object[] Synonyms { get; set; }
        public object[] Antonyms { get; set; }
    }
}
