﻿using BajtpikOOD;
using Project1_Adapter;
using Project2_Collections;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Project3_Builder {
    public class BookBuilderBase : ResourceBuilder, BookBuilder {
        private MainFormat.Book book;
        private List<string> fields;
        public BookBuilderBase() {
            this.book = new MainFormat.Book();
            this.fields = new List<string>();
        }

        public void AddPageCount(int pageCount) {
            this.book.PageCount = pageCount;
        }

        public void AddTitle(string title) {
            this.book.Title = title;
        }

        public void AddYear(int year) {
            this.book.Year = year;
        }

        public List<string> GetFields() {
            if (this.fields.Count == 0)
                this.fields.AddRange(Util.GetFields(typeof(MainFormat.Author)));
            return this.fields;
        }

        public ResourceBuilder ResetData() {
            this.fields.Clear();
            this.book = new MainFormat.Book();
            return this;
        }

        public Resource GetResource() {
            return this.book;
        }

        public ResourceBuilder SetResource(Resource resource) {
            this.book = (MainFormat.Book)resource;
            return this;
        }
    }

    public class BookBuilderSecondary : ResourceBuilder, BookBuilder {
        private SecondaryFormat.Book book;
        private List<string> fields;
        private Dictionary<int, int> intMap;
        private Dictionary<int, string> stringMap;
        public BookBuilderSecondary() {
            this.book = new SecondaryFormat.Book();
            this.fields = new List<string>();
            this.intMap = Client.Program.intMap;
            this.stringMap = Client.Program.stringMap;
        }

        public void AddPageCount(int pageCount) {
            intMap.Add(intMap.Count, pageCount);
            this.book.PageCount = intMap.Count - 1;
        }

        public void AddTitle(string title) {
            stringMap.Add(stringMap.Count, title);
            this.book.Title = stringMap.Count - 1;
        }

        public void AddYear(int year) {
            intMap.Add(intMap.Count, year);
            this.book.Year = intMap.Count - 1;
        }

        public List<string> GetFields() {
            if (this.fields.Count == 0)
                this.fields.AddRange(Util.GetFields(typeof(MainFormat.Author)));
            return this.fields;
        }

        public ResourceBuilder ResetData() {
            this.fields.Clear();
            this.book = new SecondaryFormat.Book();
            return this;
        }

        public Resource GetResource() {
            return new BookAdapter(this.book, 1);
        }

        public ResourceBuilder SetResource(Resource resource) {
            this.book = (SecondaryFormat.Book)resource;
            return this;
        }
    }

    public class NewsPaperBuilderBase : ResourceBuilder, NewsPaperBuilder {
        private MainFormat.NewsPaper newsPaper;
        private List<string> fields;
        public NewsPaperBuilderBase() {
            this.newsPaper = new MainFormat.NewsPaper();
            this.fields = new List<string>();
        }

        public void AddPageCount(int pageCount) {
            this.newsPaper.PageCount = pageCount;
        }

        public void AddTitle(string title) {
            this.newsPaper.Title = title;
        }

        public void AddYear(int year) {
            this.newsPaper.Year = year;
        }

        public ResourceBuilder ResetData() {
            this.fields.Clear();
            this.newsPaper = new MainFormat.NewsPaper();
            return this;
        }

        public Resource GetResource() {
            return this.newsPaper;
        }
        public List<string> GetFields() {
            if (this.fields.Count == 0)
                this.fields.AddRange(Util.GetFields(typeof(MainFormat.Author)));
            return this.fields;
        }

        public ResourceBuilder SetResource(Resource resource) {
            this.newsPaper = (MainFormat.NewsPaper)resource;
            return this;
        }
    }

    public class NewsPaperBuilderSecondary : ResourceBuilder, NewsPaperBuilder {
        private SecondaryFormat.NewsPaper newsPaper;
        private List<string> fields;
        private Dictionary<int, int> intMap;
        private Dictionary<int, string> stringMap;
        public NewsPaperBuilderSecondary() {
            this.newsPaper = new SecondaryFormat.NewsPaper();
            this.fields = new List<string>();
            this.intMap = Client.Program.intMap;
            this.stringMap = Client.Program.stringMap;
        }

        public void AddPageCount(int pageCount) {
            intMap.Add(intMap.Count, pageCount);
            this.newsPaper.PageCount = intMap.Count - 1;
        }

        public void AddTitle(string title) {
            stringMap.Add(stringMap.Count, title);
            this.newsPaper.Title = stringMap.Count - 1;
        }

        public void AddYear(int year) {
            intMap.Add(intMap.Count, year);
            this.newsPaper.Year = intMap.Count - 1;
        }

        public ResourceBuilder ResetData() {
            this.fields.Clear();
            this.newsPaper = new SecondaryFormat.NewsPaper();
            return this;
        }

        public Resource GetResource() {
            return new NewsPaperAdapter(this.newsPaper, 1);
        }
        public List<string> GetFields() {
            if (this.fields.Count == 0)
                this.fields.AddRange(Util.GetFields(typeof(MainFormat.Author)));
            return this.fields;
        }

        public ResourceBuilder SetResource(Resource resource) {
            this.newsPaper = (SecondaryFormat.NewsPaper)resource;
            return this;
        }
    }

    public class BoardGameBuilderBase : ResourceBuilder, BoardGameBuilder {
        private MainFormat.BoardGame boardGame;
        private List<string> fields;
        public BoardGameBuilderBase() {
            this.boardGame = new MainFormat.BoardGame();
            this.fields = new List<string>();
        }

        public void AddTitle(string title) {
            this.boardGame.Title = title;
        }

        public void AddMinPlayer(int player) {
            this.boardGame.MinPlayer = player;
        }

        public void AddMaxPlayer(int player) {
            this.boardGame.MaxPlayer = player;
        }

        public void AddDifficulty(int difficulty) {
            this.boardGame.Difficulty = difficulty;
        }

        public ResourceBuilder ResetData() {
            this.fields.Clear();
            this.boardGame = new MainFormat.BoardGame();
            return this;
        }

        public Resource GetResource() {
            return this.boardGame;
        }

        public List<string> GetFields() {
            if(this.fields.Count == 0)
                this.fields.AddRange(Util.GetFields(typeof(MainFormat.Author)));
            return this.fields;
        }

        public ResourceBuilder SetResource(Resource resource) {
            this.boardGame = (MainFormat.BoardGame)resource;
            return this;
        }
    }

    public class BoardGameBuilderSecondary : ResourceBuilder, BoardGameBuilder {
        private SecondaryFormat.BoardGame boardGame;
        private List<string> fields;
        private Dictionary<int, int> intMap;
        private Dictionary<int, string> stringMap;
        public BoardGameBuilderSecondary() {
            this.boardGame = new SecondaryFormat.BoardGame();
            this.fields = new List<string>();
            this.intMap = Client.Program.intMap;
            this.stringMap = Client.Program.stringMap;
        }

        public void AddTitle(string title) {
            stringMap.Add(stringMap.Count, title);
            this.boardGame.Title = stringMap.Count - 1;
        }

        public void AddMinPlayer(int player) {
            intMap.Add(intMap.Count, player);
            this.boardGame.MinPlayer = intMap.Count - 1;
        }

        public void AddMaxPlayer(int player) {
            intMap.Add(intMap.Count, player);
            this.boardGame.MaxPlayer = intMap.Count - 1;
        }

        public void AddDifficulty(int difficulty) {
            intMap.Add(intMap.Count, difficulty);
            this.boardGame.Difficulty = intMap.Count - 1;
        }

        public ResourceBuilder ResetData() {
            this.fields.Clear();
            this.boardGame = new SecondaryFormat.BoardGame();
            return this;
        }

        public Resource GetResource() {
            return new BoardGameAdapter(this.boardGame, 1);
        }
        public List<string> GetFields() {
            if (this.fields.Count == 0)
                this.fields.AddRange(Util.GetFields(typeof(MainFormat.Author)));
            return this.fields;
        }

        public ResourceBuilder SetResource(Resource resource) {
            this.boardGame = (SecondaryFormat.BoardGame)resource;
            return this;
        }
    }

    public class AuthorBuilderBase : ResourceBuilder, AuthorBuilder {
        private MainFormat.Author author;
        private List<string> fields;
        public AuthorBuilderBase() {
            this.author = new MainFormat.Author();
            this.fields = new List<string>();
        }

        public void AddBirthYear(int year) {
            this.author.BirthYear = year;
        }

        public void AddName(string name) {
            this.author.Name = name;
        }

        public void AddNickname(string nickname) {
            this.author.Surname = nickname;
        }

        public void AddSurname(string surname) {
            this.author.Surname = surname;
        }

        public ResourceBuilder ResetData() {
            this.fields.Clear();
            this.author = new MainFormat.Author();
            return this;
        }

        public Resource GetResource() {
            return this.author;
        }
        public List<string> GetFields() {
            if (this.fields.Count == 0)
                this.fields.AddRange(Util.GetFields(typeof(MainFormat.Author)));
            return this.fields;
        }

        public ResourceBuilder SetResource(Resource resource) {
            this.author = (MainFormat.Author)resource;
            return this;
        }
    }

    public class AuthorBuilderSecondary : ResourceBuilder, AuthorBuilder {
        private SecondaryFormat.Author author;
        private List<string> fields;
        private Dictionary<int, int> intMap;
        private Dictionary<int, string> stringMap;
        public AuthorBuilderSecondary() {
            this.author = new SecondaryFormat.Author();
            this.fields = new List<string>();
            this.intMap = Client.Program.intMap;
            this.stringMap = Client.Program.stringMap;
        }

        public void AddBirthYear(int year) {
            intMap.Add(intMap.Count, year);
            this.author.BirthYear = intMap.Count - 1;
        }

        public void AddName(string name) {
            stringMap.Add(stringMap.Count, name);
            this.author.Name = stringMap.Count - 1;
        }

        public void AddNickname(string nickname) {
            stringMap.Add(stringMap.Count, nickname);
            this.author.Surname = stringMap.Count - 1;
        }

        public void AddSurname(string surname) {
            stringMap.Add(stringMap.Count, surname);
            this.author.Surname = stringMap.Count - 1;
        }

        public ResourceBuilder ResetData() {
            this.fields.Clear();
            this.author = new SecondaryFormat.Author();
            return this;
        }

        public Resource GetResource() {
            return new AuthorAdapter(this.author, 1);
        }
        public List<string> GetFields() {
            if(this.fields.Count == 0)
                this.fields.AddRange(Util.GetFields(typeof(MainFormat.Author)));
            return this.fields;
        }

        public ResourceBuilder SetResource(Resource resource) {
            this.author = (SecondaryFormat.Author)resource;
            return this;
        }
    }
    

    //Director
    public class Director {
        private ResourceBuilder? resourceBuilder;
        Dictionary<string, Action<ResourceBuilder, string>> resourceActions;
        BajtpikCollection<Resource>? collection;
        public List<string> Arguments { get; private set; }
        public bool Cancelled;

        public Director() {
            this.collection = null;
            resourceBuilder = null;
            resourceActions = new Dictionary<string, Action<ResourceBuilder, string>>();
            this.Cancelled = false;
            this.Arguments = new List<string>();
        }

        public void MakeResource(ResourceBuilder bookBuilder, BajtpikCollection<Book> collection) {
           this.resourceBuilder = (ResourceBuilder?)bookBuilder;

            this.resourceActions["title"] = (book, title) => ((BookBuilder)book).AddTitle(title);
            this.resourceActions["year"] = (book, year) => ((BookBuilder)book).AddYear(int.Parse(year));
            this.resourceActions["pagecount"] = (book, pagecount) => ((BookBuilder)book).AddPageCount(int.Parse(pagecount));
            DoActions();

            if (!Cancelled) {
                collection.Add((Book)this.resourceBuilder?.GetResource()!);
                Console.WriteLine("[Book added successfuly]");
            }
            else {
                Console.WriteLine("[Book add failed]");
            }
        }

        public void MakeResource(ResourceBuilder newsPaperBuilder, BajtpikCollection<NewsPaper> collection) {
            this.resourceBuilder = (ResourceBuilder?)newsPaperBuilder;

            this.resourceActions["title"] = (nwp, title) => ((NewsPaperBuilder)nwp).AddTitle(title);
            this.resourceActions["year"] = (nwp, year) => ((NewsPaperBuilder)nwp).AddYear(int.Parse(year));
            this.resourceActions["pagecount"] = (nwp, pagecount) => ((NewsPaperBuilder)nwp).AddPageCount(int.Parse(pagecount));
            DoActions();

            if (!Cancelled) {
                collection.Add((NewsPaper)this.resourceBuilder?.GetResource()!);
                Console.WriteLine("[News paper added successfuly]");
            }
            else {
                Console.WriteLine("[News paper add failed]");
            }
        }

        public void MakeResource(ResourceBuilder boardGameBuilder, BajtpikCollection<BoardGame> collection) {
            this.resourceBuilder = (ResourceBuilder?)boardGameBuilder;

            this.resourceActions["title"] = (bgm, title) => ((BoardGameBuilder)bgm).AddTitle(title);
            this.resourceActions["minplayer"] = (bgm, player) => ((BoardGameBuilder)bgm).AddMinPlayer(int.Parse(player));
            this.resourceActions["maxplayer"] = (bgm, player) => ((BoardGameBuilder)bgm).AddMaxPlayer(int.Parse(player));
            this.resourceActions["difficulty"] = (bgm, diff) => ((BoardGameBuilder)bgm).AddMaxPlayer(int.Parse(diff));
            DoActions();

            if (!Cancelled) {
                collection.Add((BoardGame)this.resourceBuilder?.GetResource()!);
                Console.WriteLine("[Board game added successfuly]");
            }
            else {
                Console.WriteLine("[Board game add failed]");
            }
        }

        public void MakeResource(ResourceBuilder authorBuilder, BajtpikCollection<Author> collection) {
            this.resourceBuilder = (ResourceBuilder?)authorBuilder;

            this.resourceActions["name"] = (auth, name) => ((AuthorBuilder)auth).AddName(name);
            this.resourceActions["surname"] = (auth, surname) => ((AuthorBuilder)auth).AddName(surname);
            this.resourceActions["nickname"] = (auth, nickname) => ((AuthorBuilder)auth).AddName(nickname);
            this.resourceActions["birthyear"] = (auth, birthyear) => ((AuthorBuilder)auth).AddName(birthyear);
            DoActions();

            if (!Cancelled) {
                collection.Add((Author)this.resourceBuilder?.GetResource()!);
                Console.WriteLine("[Author added successfuly]");
            }
            else {
                Console.WriteLine("[Author add failed]");
            }
        }

        public Director AddArguments(List<string> args) {
            this.Arguments = args.GetRange(0, args.Count);
            return this;
        }

        private void DoActions() {
                if(this.Arguments.Count == 0) {
                this.Cancelled = true;
                return;
                }
                foreach(var arg in this.Arguments) {
                    List<string> parsedInput = Util.GetFieldVal(arg);
                    try {
                        this.resourceActions[parsedInput[0].ToLower()](this.resourceBuilder!, parsedInput[1]);
                    }
                    catch (Exception e) {
                        this.Cancelled = true;
                        Console.WriteLine($"Add error: [{e.Message}]");
                    }
                }    
        }
    }
}
