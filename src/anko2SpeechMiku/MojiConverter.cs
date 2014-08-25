using NMeCab;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anko2SpeachMiku
{
    class MojiConverter
    {
        /// <summary>
        /// 任意の文字列をひらがなに変換します
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public static string ConvertToHiragana(string sentence)
        {
            string katakana = "";
            string hiragana = "";
            try
            {
                MeCabTagger t = MeCabTagger.Create();
                MeCabNode node = t.ParseToNode(sentence);
                while (node != null)
                {
                    if (node.CharType > 0)
                    {
                        //結果を,で区切る
                        var s = node.Feature.Split(',');

                        if (s.Length == 7)
                        {
                            //アルファベット、記号だった場合は元の文字
                            katakana += node.Surface;
                        }
                        else
                        {
                            //日本語文字だった場合はヨミ（カタカナ）
                            katakana += s[7];
                        }
                    }
                    node = node.Next;
                }
                //ヒラガナ変換
                hiragana = CSharp.Japanese.Kanaxs.Kana.ToHiragana(katakana);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Debug.Print(e.Message);
            }
            return hiragana;
        }
    }
}
