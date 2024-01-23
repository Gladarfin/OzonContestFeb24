var n = int.Parse(Console.ReadLine());

for (var i = 0; i < n; i++)
{
        var commentTreeDict = new Dictionary<int, Comment>();
        commentTreeDict = GetDictionaryFromInput();

        var result = GroupCommentsToCommentTreeByRoot(commentTreeDict);

        foreach (var tree in result.Children.Values)
        {
            WriteToConsole(tree, "");
            Console.WriteLine("");
        }

        continue;

        Dictionary<int, Comment> GetDictionaryFromInput()
        {

            var commentsCount = int.Parse(Console.ReadLine());
            var result = new Dictionary<int, Comment>();

            for (var j = 0; j < commentsCount; j++)
            {
                var curComment = Console.ReadLine().Split(' ');
                result.Add(int.Parse(curComment[0]), new Comment
                {
                    Id = int.Parse(curComment[0]),
                    ParentId = int.Parse(curComment[1]),
                    Text = string.Join(" ", curComment.Skip(2)),
                    Children = new SortedList<int, Comment>()
                });
            }

            return result;
        }

        Comment GroupCommentsToCommentTreeByRoot(Dictionary<int, Comment> inputDictionary)
        {
            var commentTreeRoot = new Comment
            {
                Children = new SortedList<int, Comment>()
            };

            foreach (var comment in inputDictionary.Values)
            {
                if (comment.ParentId != -1)
                {
                    inputDictionary[comment.ParentId].Children.Add(comment.Id, comment);
                    continue;
                }

                commentTreeRoot.Children.Add(comment.Id, comment);
            }

            return commentTreeRoot;
        }

        void WriteToConsole(Comment commentTree, string prefix)
        {
            Console.WriteLine(commentTree.Text);
            for (var i = 0; i < commentTree.Children.Count; i++)
            {
                Console.WriteLine(prefix + '|');
                Console.Write(prefix + "|--");

                if (i == commentTree.Children.Count - 1)
                {
                    WriteToConsole(commentTree.Children.Values[i], prefix + "   ");
                    continue;
                }

                WriteToConsole(commentTree.Children.Values[i], prefix + "|  ");
            }
        }
}

class Comment
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public string Text { get; set; }
    public SortedList<int ,Comment> Children { get; set; }
} 