using MarcosCosta.Domain.Interfaces.Repositories.Externals;
using Microsoft.Extensions.Options;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using MarcosCosta.Domain.Extensions;
using MarcosCosta.Domain.Options;
using Microsoft.Extensions.Logging;

namespace MarcosCosta.Repository.Externals
{
    public class FeedRDFRepository : IFeedRDFRepository
    {
        private readonly IOptions<AppSettings> _options;
        private readonly ILogger<FeedRDFRepository> _logger;
        public FeedRDFRepository(IOptions<AppSettings> options, ILogger<FeedRDFRepository> logger)
        {
            _options = options;
            _logger = logger;
        }

        public async Task<RDF> ImportFeeds()
        {
            RDF? rdf;
            string strXml;
            MemoryStream memoryStream;
            var xmlFilePath = $"{Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%")}\\{_options.Value.XMLFileName}";

            var serializer = new XmlSerializer(typeof(RDF));
            var settings = new XmlWriterSettings { Indent = true, IndentChars = " ", NewLineOnAttributes = true, CloseOutput = true };

            _logger.LogInformation($"Iniciando processo de leitura de feeds, na url: {_options.Value.FeedRDFUrl}");

            using (XmlReader xmlReader = new XmlTextReader(_options.Value.FeedRDFUrl))
            using (XmlWriter xmlWriter = XmlWriter.Create(File.OpenWrite(xmlFilePath), settings))
            xmlWriter.WriteNode(xmlReader, true);

            _logger.LogInformation($"Processo de leitura concluído com sucesso");
            _logger.LogInformation($"Iniciando processo de escrita do arquivo: {xmlFilePath}");

            using (var reader = new StreamReader(xmlFilePath))
            strXml = reader.ReadToEnd();
            memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(strXml.Unescape()));
            rdf = serializer.Deserialize(memoryStream) as RDF;

            _logger.LogInformation($"Arquivo salvo com sucesso");

            return await Task.FromResult(rdf ?? new RDF());
        }
    }
}