using System;
using System.Net.Http.Formatting;

namespace Responsible.Handler.WebApi
{
    internal static class MediaFormatExtentions
    {
        internal static MediaTypeFormatter MediaTypeFormatter(this MediaFormat mediaFormat)
        {
            switch (mediaFormat)
            {
                case MediaFormat.JSon:
                    return new JsonMediaTypeFormatter();
                case MediaFormat.Xml:
                    return new XmlMediaTypeFormatter();
                default:
                    throw new ArgumentOutOfRangeException(nameof(mediaFormat), mediaFormat, null);
            }
        }
    }
}