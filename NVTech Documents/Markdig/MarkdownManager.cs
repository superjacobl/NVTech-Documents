using Markdig.Extensions.MediaLinks;
using Markdig;
using System.Text.RegularExpressions;

namespace NVTech_Documents.Markdig;

public static class MarkdownManager
{
	public static MarkdownPipeline pipeline;

	static MarkdownManager()
	{

		pipeline = new MarkdownPipelineBuilder().DisableHtml()
												.UseMathematics()
												.UseAbbreviations()
												.UseCitations()
												.UseCustomContainers()
												.UseDiagrams()
												.UseFigures()
												.UseFootnotes()
												.UseGlobalization()
												.UseGridTables()
												.UseListExtras()
												.UsePipeTables()
												.UseTaskLists()
												.UseEmphasisExtras()
												.UseEmojiAndSmiley(true)
												.UseReferralLinks("nofollow")
												.UseSoftlineBreakAsHardlineBreak()
												.Build();
	}

	public static readonly Regex sanitizeLink = new("(?<=follow\">).+?(?=<)");

	public static string GetHtml(string content)
	{
		if (content is null)
			return "";

		string markdown = "Error: Message could not be parsed.";

		try
		{
			markdown = Markdown.ToHtml(content, pipeline);
		}
		catch (Exception e)
		{
			Console.WriteLine("Error parsing message!");
			Console.WriteLine("This may be nothing to worry about, a user may have added an insane table or such.");
			Console.WriteLine(e.Message);
		}

		markdown = markdown.Replace("(&", "<center>");
		markdown = markdown.Replace("&)", "</center>");
		markdown = markdown.Replace("§", "Sec ");
		markdown = markdown.Replace("  ", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");

		var chars = "";
		bool triggered = false;
		foreach(char c in markdown)
		{
			if (triggered)
			{
				if (c == ' '|| c == ',')
				{
					triggered = false;
					var code = chars;
					code = code.Replace(".", "/");
					markdown = markdown.Replace($"@{chars}", $"<a href'/code/{code}'>§{chars}</a>");
					chars = "";
					continue;
				}
				chars += c;
			}
			if (c == '@')
				triggered = true;
		}

		return markdown;
	}
}
