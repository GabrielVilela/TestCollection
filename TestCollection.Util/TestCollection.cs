using System.Collections.Generic;
using System.Linq;
using TestCollection.Util.Interfaces;

namespace TestCollection.Util
{
    public class TestCollection: ITestCollection
    {
        private Dictionary<string, Dictionary<int, List<string>>> TestColl { get; set; }

        public TestCollection()
        {
            this.TestColl = new Dictionary<string, Dictionary<int, List<string>>>();
        }

        public bool Add(string key, int subIndex, string value)
        {
            if (this.TestColl.ContainsKey(key))
            {
                if (this.TestColl[key].ContainsKey(subIndex))
                {
                    if (this.TestColl[key][subIndex].Contains(value))
                    {
                        return false;
                    }
                    else
                    {
                        this.TestColl[key][subIndex].Add(value);
                        this.TestColl[key][subIndex] = this.TestColl[key][subIndex].OrderBy(x => x).ToList();
                        
                    }
                }
                else
                {
                    List<string> list = new List<string>();
                    list.Add(value);
                    this.TestColl[key].Add(subIndex, list);
                    var dic = this.TestColl[key].OrderBy(x => x.Key);
                    this.TestColl[key] = dic.ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value);
                }
                bool removed = false;
                foreach (var l in this.TestColl[key])
                {
                    if(l.Key != subIndex)
                    {
                        if (l.Value.Contains(value))
                        {
                            l.Value.Remove(value);
                            removed = true;
                        }
                    }
                }
                if (removed)
                    return false;
                return true;
            }
            else
            {
                List<string> list = new List<string>();
                list.Add(value);
                Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
                dict.Add(subIndex, list);
                this.TestColl.Add(key, dict);
                var dic = this.TestColl.OrderBy(x => x.Key);
                this.TestColl = dic.ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value);
                return true;
            }
        }

        public bool RemoveValuesFromSubIndex(string key, int subIndex)
        {
            if (this.TestColl.ContainsKey(key))
            {
                if (this.TestColl[key].ContainsKey(subIndex))
                {
                    this.TestColl[key].Remove(subIndex);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        public bool Remove(string key)
        {
            if (this.TestColl.ContainsKey(key))
            {
                this.TestColl.Remove(key);
                return true;
            }
            else
                return false;
        }

        public IList<string> Get(string key, int start, int end)
        {
            int indexStart = start;
            int indexEnd = end + 1;
            List<string> returnList = new List<string>();
            if (end >= 0)
            {
                if (start < 0)
                {
                    indexStart = 0;
                }
                if (this.TestColl.ContainsKey(key))
                {
                    var dictList = this.TestColl[key].Values;
                    foreach (var list in dictList)
                    {
                        if (list.Count >= indexStart && list.Count >= indexEnd)
                        {
                            returnList.AddRange(list.GetRange(indexStart, indexEnd - indexStart));
                            return returnList.OrderBy(x => x).ToList();
                        }
                        else
                        {
                            returnList.AddRange(list.GetRange(indexStart, list.Count - indexStart));
                        }
                        indexEnd = (end - start + 1) - returnList.Count;
                        indexStart = 0;

                    }
                }
            }
            if (end < 0)
            {
                if (start < 0)
                {
                    indexStart = 0;
                }
                var endAux = (end + 1) * (-1);
                if (this.TestColl.ContainsKey(key))
                {
                    var dictList = this.TestColl[key].Values;
                    foreach (var list in dictList)
                    {
                        if (list.Count > indexStart)
                        {
                            returnList.AddRange(list.GetRange(indexStart, list.Count - indexStart));
                        }
                        indexStart = indexStart - list.Count() <= 0 ? 0 : indexStart - list.Count();
                    }
                    returnList.RemoveRange(returnList.Count - endAux, endAux);
                }
            }
            return returnList.OrderBy(x => x).ToList();

        }
        public long IndexOf(string key, string value)
        {
            long index = 0;
            if (this.TestColl.ContainsKey(key))
            {
                var dictList = this.TestColl[key].OrderBy(x => x.Key).ToDictionary(d => d.Key, d => (IList<string>)d.Value.OrderBy(v => v).ToList()).Values;
                foreach (var list in dictList)
                {
                    var lst = list.OrderBy(x => x).ToList();
                    if (lst.Contains(value))
                    {
                        return index + lst.IndexOf(value);
                    }
                    index += lst.Count;
                }
            }
            //retorna -1 quando não há item correspondente.
            return -1;
        }
    }
}

