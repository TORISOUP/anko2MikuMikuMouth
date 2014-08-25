using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anko2SpeachMiku
{
    /// <summary>
    /// 棒読みちゃんの辞書ファイルを読み込んで使う
    /// </summary>
    class BoyomiDictionary
    {
        List<DicWord> _dicWordList = new List<DicWord>();
        public List<DicWord> dicWordList { get { return _dicWordList; } }

        /// <summary>
        /// 辞書ファイルを開く
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool Open(string filePath)
        {
            _dicWordList.Clear();

            //ファイルが存在しねぇ
            if (!File.Exists(filePath)) { return false; }

            try
            {
                using (var sr = new System.IO.StreamReader(filePath, Encoding.GetEncoding("Shift-JIS")))
                {

                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var values = line.Split('\t');
                        //書式がおかしい
                        if (values.Count() != 4) { throw new InvalidDataException("Wrong format."); }

                        var wd = new DicWord();
                        wd.priority = Int32.Parse(values[0]);
                        wd.targetString = values[2];
                        wd.replaceString = values[3].Replace("\\", "").Replace("'", "");
                        _dicWordList.Add(wd);
                    }
                }
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }

        //指定の文字列を辞書を元に置換する
        public string Replace(string original)
        {
            if (_dicWordList == null || _dicWordList.Count == 0) { return original; }
            var currentString = original.ToUpper();
            _dicWordList.OrderByDescending(x => x.priority).ToList().ForEach(x =>
            {
                currentString = currentString.Replace(x.targetString, x.replaceString);

            });

            return currentString;
        }

    }
}
