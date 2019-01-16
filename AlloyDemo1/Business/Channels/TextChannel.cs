using EPiServer.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlloyDemo1.Business.Channels
{
    public class TextChannel : DisplayChannel
    {
        public override string ChannelName => "text";

        public override bool IsActive(HttpContextBase context)
        {
            return context.Request.QueryString["Test"] == "1";
        }
    }
}