using System;
using System.Collections.Generic;

namespace Lab2
{
    class Magazine : Edition {
        private Frequency frequency;
        private List<Article> articles = new List<Article>();
        private List<Person> editors = new List<Person>();

        public Magazine(String n, Frequency f, DateTime d, int c): base(n, d, c) {
            this.frequency = f;
        }

        public Magazine():this("Time", Frequency.Montly, DateTime.Today, 1) {}

        public Frequency getFrequency() {
            return this.frequency;
        }
        public void setFrequency(Frequency f) {
            this.frequency = f;
        }

        public double AvgRating {
            get {
                Double total = 0;
                int length = this.articles.Count;
                if (length == 0) return 0;
                foreach(Article a in this.articles) {
                    total += a.rating;
                }
                return total / length;
            }
        }

        public List<Article> ArticlesList {
            get { return this.articles; }
        }

        public List<Person> EditorsList {
            get { return this.editors; }
        }

        public void addArticles(List<Article> new_articles) {
            foreach (Article a in new_articles)
                this.articles.Add(a);
        }

        public void addEditors(List<Person> new_editors) {
            foreach (Person p in new_editors)
                this.editors.Add(p);
        }

        public override String ToString() {
            String res = base.ToString();
            res += $"Frequency={frequency}\nArticles=>\n";
            foreach (Article a in articles)
                res += $"\t{a.ToString()}\n";
            res += "Editors=>\n";
            foreach (Person e in editors)
                res += $"\t{e.ToString()}\n";
            return res;
    }

        public virtual String ToShortString() {
            String res = base.ToString();
            res += $"Frequency={frequency}\nAverage Rating={AvgRating}\n";
            return res;
        }

        static void Main(string[] args) {
            Magazine m = new Magazine();
            List<Article> articles = new List<Article> { new Article() };
            List<Person> editors = new List<Person> { new Person() };
            m.addArticles(articles);
            m.addEditors(editors);
            Console.WriteLine(m.ToShortString());
            Console.WriteLine(m.ToString()); 
            Console.ReadLine();

        }

    }
}
