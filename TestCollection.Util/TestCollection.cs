using System;
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
                        return true;
                    }
                }
                else
                {
                    List<string> list = new List<string>();
                    list.Add(value);
                    this.TestColl[key].Add(subIndex, list);
                    return true;
                }
            }
            else
            {
                List<string> list = new List<string>();
                list.Add(value);
                Dictionary<int, List<string>> dict = new Dictionary<int, List<string>>();
                dict.Add(subIndex, list);
                this.TestColl.Add(key, dict);
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
                    indexEnd = end + 1 + (start * -1);
                }
                if (this.TestColl.ContainsKey(key))
                {
                    var dictList = this.TestColl[key].OrderBy(x => x.Key).ToDictionary(d => d.Key, d => (IList<string>)d.Value.OrderBy(v => v).ToList()).Values;
                    foreach (var list in dictList)
                    {
                        var lst = list.ToList();
                        if (lst.Count >= indexStart && lst.Count >= indexEnd)
                        {
                            returnList.AddRange(lst.GetRange(indexStart, indexEnd - indexStart));
                            return returnList;
                        }
                        else
                        {
                            returnList.AddRange(lst.GetRange(indexStart, lst.Count - indexStart));
                        }
                        indexEnd = (end - start + 1) - returnList.Count;
                        indexStart = 0;

                    }
                }
            }
            if (end < 0)
            {
                var endAux = (end + 1) * (-1);
                if (this.TestColl.ContainsKey(key))
                {
                    var dictList = this.TestColl[key].OrderByDescending(x => x.Key).ToDictionary(d => d.Key, d => (IList<string>)d.Value.OrderByDescending(v => v).ToList()).Values;
                    foreach (var list in dictList)
                    {
                        var lst = list.ToList();
                        if (endAux < lst.Count)
                        {
                            returnList.Add(lst[endAux]);
                            return returnList;
                        }
                        endAux -= lst.Count;
                    }
                }
            }
            return returnList;

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
            return -1;
        }
    }
}

