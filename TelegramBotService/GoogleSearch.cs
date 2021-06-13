using System;
using System.Collections.Generic;
using System.Text;

namespace TelegramBotService
{
    public partial class GoogleSearch
    {
        public string Kind { get; set; }
        public Url Url { get; set; }
        public Queries Queries { get; set; }
        public Context Context { get; set; }
        public SearchInformation SearchInformation { get; set; }
        public List<Item> Items { get; set; }
    }

    public partial class Context
    {
        public string Title { get; set; }
    }

    public partial class Item
    {
        public string Kind { get; set; }
        public string Title { get; set; }
        public string HtmlTitle { get; set; }
        public string Link { get; set; }
        public string DisplayLink { get; set; }
        public string Snippet { get; set; }
        public string HtmlSnippet { get; set; }
        public string CacheId { get; set; }
        public string FormattedUrl { get; set; }
        public string HtmlFormattedUrl { get; set; }
        public Pagemap Pagemap { get; set; }
    }

    public partial class Pagemap
    {
        public List<CseThumbnail> CseThumbnail { get; set; }
        public List<Metatag> Metatags { get; set; }
        public List<Place> Place { get; set; }
        public List<CseImage> CseImage { get; set; }
    }

    public partial class CseImage
    {
        public string Src { get; set; }
    }

    public partial class CseThumbnail
    {
        public string Src { get; set; }
        public long? Width { get; set; }
        public long? Height { get; set; }
    }

    public partial class Metatag
    {
        public string Referrer { get; set; }
        public string OgImage { get; set; }
        public long? OgImageWidth { get; set; }
        public string TwitterCard { get; set; }
        public string OgSiteName { get; set; }
        public string Viewport { get; set; }
        public string OgTitle { get; set; }
        public long? OgImageHeight { get; set; }
        public string Google { get; set; }
        public string OgDescription { get; set; }
        public string AppleItunesApp { get; set; }
        public string OgType { get; set; }
        public string TwitterTitle { get; set; }
        public string MusicCreator { get; set; }
        public string Title { get; set; }
        public string TwitterCreator { get; set; }
        public string ArticleAuthor { get; set; }
        public string TwitterImage { get; set; }
        public string OgUrl { get; set; }
        public string ThemeColor { get; set; }
        public DateTimeOffset? ArticlePublishedTime { get; set; }
        public string TwitterUrl { get; set; }
        public string TwitterImageAlt { get; set; }
        public string TwitterSite { get; set; }
        public DateTimeOffset? ArticleModifiedTime { get; set; }
        public string NewsKeywords { get; set; }
        public string FbAdmins { get; set; }
        public string OgImageAlt { get; set; }
        public string TweetmemeTitle { get; set; }
        public string FbPages { get; set; }
        public string FbAppId { get; set; }
        public string TwitterDescription { get; set; }
        public string OgLocale { get; set; }
    }

    public partial class Place
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public partial class Queries
    {
        public List<NextPage> Request { get; set; }
        public List<NextPage> NextPage { get; set; }
    }

    public partial class NextPage
    {
        public string Title { get; set; }
        public long? TotalResults { get; set; }
        public string SearchTerms { get; set; }
        public long? Count { get; set; }
        public long? StartIndex { get; set; }
        public string InputEncoding { get; set; }
        public string OutputEncoding { get; set; }
        public string Safe { get; set; }
        public string Cx { get; set; }
    }

    public partial class SearchInformation
    {
        public decimal? SearchTime { get; set; }
        public string FormattedSearchTime { get; set; }
        public long? TotalResults { get; set; }
        public string FormattedTotalResults { get; set; }
    }

    public partial class Url
    {
        public string Type { get; set; }
        public string Template { get; set; }
    }
}
