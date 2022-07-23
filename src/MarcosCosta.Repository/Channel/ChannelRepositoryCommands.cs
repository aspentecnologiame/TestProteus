using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcosCosta.Repository.Channel
{
    public static class ChannelRepositoryCommands
    {
        public const string ClearChannel = @"DELETE FROM [Channel]";

        public const string Get = @"SELECT [Id], [About], [Date], [Description], [Language], [Link], [Rights], [Title], [Created], [Updated] FROM [Channel]";

        public const string GetById = @"SELECT [Id], [About], [Date], [Description], [Language], [Link], [Rights], [Title], [Created], [Updated] FROM [Channel] WHERE [Id] = @Id";

        public const string Insert = @"INSERT INTO [Channel] ([Id], [About], [Date], [Description], [Language], [Link], [Rights], [Title], [Created], [Updated])
                                               VALUES (@Id, @About, @Date, @Description, @Language, @Link, @Rights, @Title, @Created, NULL)";
    }
}
