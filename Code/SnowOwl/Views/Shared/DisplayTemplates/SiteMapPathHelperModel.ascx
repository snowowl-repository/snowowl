<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl`1[[MvcSiteMapProvider.Web.Html.Models.SiteMapPathHelperModel,MvcSiteMapProvider]]" %>
<%@ Import Namespace="System.Web.Mvc.Html" %>
<%@ Import Namespace="MvcSiteMapProvider.Web.Html.Models" %>

<style>
    #path {
        list-style: none;
        padding: 0;
        margin: 0;
        height: 25px;
    }

    #path li {
        display: inline-block;
        margin: 0;
        padding: 0;
        vertical-align: top;
        line-height: 25px;
        color: white;
    }

    #path li img {
        float: left;
        height: 25px;
    }

    #path li a {
        text-decoration: none;
        float: left;
        line-height: 25px;
        vertical-align: top;
        color: white;
    }

    #path li a:hover { color: orange; }
    
</style>

<ul id="path">
    <% foreach (var node in Model)
        { %>
        <li>
            <%= Html.DisplayFor(m => node) %>
        </li>
        <% if (node != Model.Last())
            {%>
                <li><img src="<%= Url.Content("~/Content/images/separator.png") %>"/></li>
        <% } %>
    <% } %>
</ul>