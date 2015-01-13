using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InteractiveResponse.Model
{
    public class Sanitizer
    {        
        private string mModelPath = string.Empty;
        private OpenNLP.Tools.SentenceDetect.MaximumEntropySentenceDetector mSentenceDetector;
        private OpenNLP.Tools.Tokenize.EnglishMaximumEntropyTokenizer mTokenizer;
        private OpenNLP.Tools.PosTagger.EnglishMaximumEntropyPosTagger mPosTagger;

        public Sanitizer()
        {

        }

        public Sanitizer(string libPath)
        {
            mModelPath = libPath;
        }

        public List<string> SanitizeString(string inputSentence)
        {
            string currentPath = Environment.CurrentDirectory;
            //mModelPath = //Path.Combine(currentPath.Substring(0, currentPath.IndexOf("Source")), @"Source\Lib\NLP\");

            List<Word> lstWords = new List<Word>();
            List<string> lstResult = new List<string>();
            if (inputSentence != null)
            {
                lstWords = PosTagTokens(TokenizeSentence(inputSentence));
                if (lstWords != null)
                {
                    lstWords.RemoveAll(p => !p.Tag.Contains("NN"));
                }
                foreach (Word item in lstWords)
                {
                    lstResult.Add(item.Key);
                }
                
            }
            return lstResult;
        }

        private string[] TokenizeSentence(string sentence)
        {
            if (mTokenizer == null)
            {
                mTokenizer = new OpenNLP.Tools.Tokenize.EnglishMaximumEntropyTokenizer(mModelPath + "EnglishTok.nbin");
            }
            return mTokenizer.Tokenize(sentence);
        }

        private List<Word> PosTagTokens(string[] tokens)
        {
            if (mPosTagger == null)
            {
                mPosTagger = new OpenNLP.Tools.PosTagger.EnglishMaximumEntropyPosTagger(mModelPath + "EnglishPOS.nbin", mModelPath + @"\Parser\tagdict");
            }

            string[] Tags = mPosTagger.Tag(tokens);
            List<Word> lstWords = new List<Word>();
            for (int i = 0; i < tokens.Length; i++)
            {
                Word wd = new Word();
                wd.Key = tokens[i];
                wd.Tag = Tags[i];
                lstWords.Add(wd);
            }

            return lstWords;
        }
    }
}
