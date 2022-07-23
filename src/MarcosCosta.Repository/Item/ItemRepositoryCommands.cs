using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcosCosta.Repository.Item
{
    public static class ItemRepositoryCommands
    {
        public const string ClearItem = @"TRUNCATE TABLE [Item]";

        public const string Insert = @"INSERT INTO [Item] ([Id], [RDFId], [About], [Date], [Description], [Link], [Title], [Created], [Updated])
                                                    VALUES (@Id, @RDFId, @About, @Date, @Description, @Link, @Title, @Created, NULL)";

        public static string GetByRDFId = @"SELECT [Id], [RDFId], [About], [Date], [Description], [Link], [Title], [Created], [Updated] FROM [Item] WHERE [RDFId] = @RDFId";
    }
}
