using Microsoft.AspNetCore.Mvc.RazorPages;

namespace YoutubeToText.Pages.Learn;

public class FirmaUndFirmengrundsaetzeModel : PageModel
{
    public record Block(string De, string Ru);

    public List<Block> Blocks { get; } = new()
    {
        new("Rechtliche Grundlagen: Firma und Firmengrundsätze.", "Правовые основы: фирма и принципы фирменного наименования."),
        new("Nachdem Sie ihren Cousin beim Thema Kaufmannsarten so gut informieren konnten, haben Sie eine Weile nichts von ihm gehört.", "После того как вы хорошо проинформировали двоюродного брата о видах предпринимателей, вы некоторое время ничего о нём не слышали."),
        new("Dann aber erreicht Sie folgende WhatsApp.", "Но затем вы получаете следующее сообщение в WhatsApp."),
        new("Arbeitsauftrag 1: Schauen Sie das Erklärvideo zu den Firmengrundsätzen.", "Задание 1: посмотрите обучающее видео о принципах фирменного наименования."),
        new("Informieren Sie sich außerdem anhand des Informationsblattes über die Firma und die Firmengrundsätze.", "Кроме того, ознакомьтесь с информационным листом о фирме и принципах фирменного наименования."),
        new("Arbeitsauftrag 2: Beurteilen Sie die beiden Vorschläge Ihres Cousins.", "Задание 2: оцените два предложения вашего двоюродного брата."),
        new("Um welche Art von Firmenbezeichnung handelt es sich bei den Vorschlägen?", "К какому виду фирменных наименований относятся эти предложения?"),
        new("Was spricht für oder gegen die Vorschläge Ihres Cousins?", "Что говорит за или против предложений вашего двоюродного брата?"),
        new("Formulieren Sie eine kurze WhatsApp, in der Sie Ihrem Cousin antworten.", "Сформулируйте короткое сообщение в WhatsApp, в котором вы ответите двоюродному брату."),
        new("Vertiefende Fragen zu Firma und Firmengrundsätze.", "Углубляющие вопросы о фирме и принципах фирменного наименования."),
        new("Wie muss ein Namensvetter von Ihrem Cousin, der letztendlich mit „P. Müller e. K. T‑Shirt‑Einzelhandel“ in das Handelsregister eingetragen ist, firmieren, damit er nicht gegen den Firmengrundsatz der Firmenausschließlichkeit verstößt?", "Как должен называться тёзка вашего двоюродного брата, который в итоге зарегистрирован в торговом реестре как «P. Müller e. K. T‑Shirt‑Einzelhandel», чтобы не нарушить принцип исключительности фирменного наименования?"),
        new("Wie könnte sich die Heinrich KG nennen, wenn es sich (a) um eine Sachfirma, (b) um eine Mischfirma, (c) um eine Fantasiefirma handeln würde?", "Как могла бы называться Heinrich KG, если это (a) предметная фирма, (b) смешанная фирма, (c) фантазийная фирма?"),
        new("Nennen Sie drei zulässige Firmierungen, um nicht gegen den Firmengrundsatz der Firmenbeständigkeit zu verstoßen, wenn Bodo Lukas den Büromöbeleinzelhandel von Herbert Blank erwirbt.", "Назовите три допустимых варианта фирменного наименования, чтобы не нарушить принцип устойчивости фирмы, если Бодо Лукас приобретает розничную торговлю офисной мебелью у Герберта Бланка."),
        new("Hey du, ich bereite gerade meine Eintragung ins Handelsregister vor.", "Привет, я сейчас готовлюсь к внесению в торговый реестр."),
        new("Dort muss ich die Firma eintragen.", "Там мне нужно зарегистрировать фирму."),
        new("So einen richtig offiziellen Firmennamen habe ich bisher gar nicht.", "Официального фирменного названия у меня пока нет."),
        new("Ich habe zwei Favoriten und würde gerne deine Meinung dazu wissen:", "У меня есть два фаворита, и я хотел бы узнать твоё мнение:"),
        new("International Shirt Company Professor Müller e. K.", "International Shirt Company Professor Müller e. K."),
        new("Shirtastic – Individuelle Shirts, Inhaber P. Müller e. K.", "Shirtastic – Individuelle Shirts, Inhaber P. Müller e. K."),
        new("Was würdest du nehmen?", "Что бы ты выбрал?"),
        new("Ich finde, der erste Vorschlag macht etwas mehr her.", "Мне кажется, первый вариант звучит солиднее."),
        new("Viele Grüße, Peter.", "С наилучшими пожеланиями, Петер."),
    };

    public void OnGet() { }
}
