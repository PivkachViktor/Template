using System;
using System.Collections.Generic;


class Event
{
    public string Date { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
}

class Page
{
    public string Header { get; set; }
    public List<Event> Events { get; set; }
    public List<string> Announcements { get; set; }
    public string Footer { get; set; }
}

// Інтерфейс для будівельника
interface IPageBuilder
{
    void BuildHeader(string headerText);
    void BuildEvents(List<Event> events);
    void BuildAnnouncements(List<string> announcements);
    void BuildFooter(List<string> authors);
    Page GetPage();
}


class FullPageBuilder : IPageBuilder
{
    private Page page = new Page();

    public void BuildHeader(string headerText)
    {
        page.Header = $"<header>{headerText}</header>";
    }

    public void BuildEvents(List<Event> events)
    {
        page.Events = events;
    }

    public void BuildAnnouncements(List<string> announcements)
    {
        page.Announcements = announcements;
    }

    public void BuildFooter(List<string> authors)
    {
        page.Footer = $"<footer>Authors: {string.Join(", ", authors)}</footer>";
    }

    public Page GetPage()
    {
        return page;
    }
}


class PageDirector
{
    private IPageBuilder builder;

    public PageDirector(IPageBuilder builder)
    {
        this.builder = builder;
    }

    public void Construct(string headerText, List<Event> events, List<string> announcements, List<string> authors)
    {
        builder.BuildHeader(headerText);
        builder.BuildEvents(events);
        builder.BuildAnnouncements(announcements);
        builder.BuildFooter(authors);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var events = new List<Event>
        {
            new Event { Date = "2023-01-01", Title = "День Народження", Description = "зустріч в 18", ImageUrl = "image1.jpg" },
            new Event { Date = "2023-02-01", Title = "Модуль", Description = "зустріч на 10 ранку ", ImageUrl = "image2.jpg" }
        };
        var announcements = new List<string> { "Event 1", "Event 2" };
        var authors = new List<string> { "Author 1", "Author 2" };

        var fullPageBuilder = new FullPageBuilder();
        var director = new PageDirector(fullPageBuilder);
        director.Construct("My Events Page", events, announcements, authors);
        var page = fullPageBuilder.GetPage();

        // Генерація HTML сторінки
        var html = $"{page.Header}<ul>";
        foreach (var ev in page.Events)
        {
            html += $"<li>{ev.Date} - {ev.Title}: {ev.Description}</li>";
        }
        html += "</ul>";
        html += $"<div>Announcements: {string.Join(", ", page.Announcements)}</div>";
        html += page.Footer;

        // Виведення HTML сторінки в консоль
        Console.WriteLine(html);
    }
}
