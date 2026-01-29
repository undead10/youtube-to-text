using Microsoft.AspNetCore.Mvc.RazorPages;

namespace YoutubeToText.Pages.Learn;

public class KaufmannModel : PageModel
{
    public record Block(string De, string Ru);

    public List<Block> Blocks { get; } = new()
    {
        new("Was sind Kaufmannseigenschaften und welche Kaufmannsarten gibt es?", "Что такое качества предпринимателя и какие виды предпринимателей существуют?"),
        new("Das erfährst du hier.", "Это ты узнаешь здесь."),
        new("Kaufmannseigenschaften entscheiden, ob du offiziell als Kaufmann giltst.", "Качества предпринимателя определяют, считаешься ли ты официально предпринимателем."),
        new("Dabei kann ein Kaufmann sowohl eine Person als auch ein ganzes Unternehmen sein.", "При этом предпринимателем может быть как человек, так и целое предприятие."),
        new("Das bringt bestimmte Rechte, aber auch Pflicht mit sich.", "Это влечёт определённые права, но и обязанности."),
        new("Das alles ist im Handelsgesetzbuch, kurz HGB geregelt.", "Всё это регулируется Торговым кодексом, сокращённо HGB."),
        new("Ob du als Kaufmannshälst, hängt davon ab, ob dein Betrieb ein Gewerbe ist und wie groß oder komplex er organisiert ist.", "Считаешься ли ты предпринимателем, зависит от того, является ли твой бизнес торговым предприятием и насколько он крупный или сложный."),
        new("Ein Gewerbe ist eine selbstständige, auf Dauer angelegte Tätigkeit, mit der du regelmäßig Gewinn erzielen möchtest.", "Предприятие — это самостоятельная деятельность, рассчитанная на длительный срок, с целью регулярной прибыли."),
        new("Außerdem wird zwischen verschiedenen Kaufmannsarten unterschieden.", "Кроме того, различают разные виды предпринимателей."),
        new("Schauen wir uns dafür zuerst den Ist-Kaufmann-Nähe an.", "Сначала рассмотрим так называемого Ist‑Kaufmann."),
        new("Ein Ist-Kaufmann ist jemand, der ein Handelsgewerbe betreibt.", "Ist‑Kaufmann — это тот, кто ведёт торговое предприятие."),
        new("Das ist ein Gewerbe, das dauerhaft auf Gewinnerzielung ausgerichtet ist.", "Это бизнес, который постоянно ориентирован на получение прибыли."),
        new("Das Gewerbe muss groß genug sein, damit eine kaufmännische Organisation notwendig ist, zum Beispiel durch viele mitarbeitende oder komplexe Abläufe.", "Предприятие должно быть достаточно крупным, чтобы требовалась коммерческая организация, например из‑за большого числа сотрудников или сложных процессов."),
        new("Stell dir vor, du betreibst eine Bäckerei mit mehreren Filialen und Angestellten.", "Представь, что ты ведёшь пекарню с несколькими филиалами и сотрудниками."),
        new("Weil dein Geschäft recht groß ist, braucht es eine kaufmännische Organisation.", "Поскольку твой бизнес довольно большой, ему нужна коммерческая организация."),
        new("Das macht dich zum Ist-Kaufmann.", "Это делает тебя Ist‑Kaufmann."),
        new("Du musst dich somit ins Handelsregister eintragen und die Regeln des Handelsgesetzbuches einhalten.", "Поэтому ты обязан внести себя в торговый реестр и соблюдать правила Торгового кодекса."),
        new("Kommen wir jetzt zur nächsten Kaufmannsart.", "Перейдём к следующему виду предпринимателя."),
        new("Als Form-Kaufmann bist du ein Unternehmer, der durch seine Rechtsform, wie eine GmbH oder eine AG, automatisch kaufmann ist.", "Form‑Kaufmann — это предприниматель, который из‑за своей правовой формы (например, GmbH или AG) автоматически считается предпринимателем."),
        new("Wenn du also eine GmbH für eine Schuhmark gegründest, bist du Form-Kaufmann.", "Если ты основал GmbH для обувного бренда, ты — Form‑Kaufmann."),
        new("Selbst wenn du erst mal nur online und an Freunde verkaufst, hier zählt nur die Rechtsform, nicht die Unternehmensgröße.", "Даже если ты пока продаёшь только онлайн и друзьям, здесь важна лишь правовая форма, а не размер компании."),
        new("Der Kann-Kaufmann hingegen hat die Wahl, ob er sich ins Handelsregister eintragen möchte.", "Kann‑Kaufmann, напротив, сам решает, вноситься ли ему в торговый реестр."),
        new("Jedoch ist er dann auch an die Rechte und Pflichten der Kaufleute gebunden.", "Но тогда он также обязан соблюдать права и обязанности предпринимателей."),
        new("Zu den Kann-Kauf-Männern zählen zum Beispiel Kleingewerbetreibende und Landwirte.", "К Kann‑Kaufmann относятся, например, мелкие предприниматели и фермеры."),
        new("Nehmen wir an, du verkaufst Obst auf Märkten.", "Предположим, ты продаёшь фрукты на рынках."),
        new("Normalerweise wärst du als einfacher Obsthändler kein Kaufmann.", "Обычно как обычный торговец фруктами ты не являешься предпринимателем."),
        new("Du kannst jedoch freiwillig Kaufmann werden, um zum Beispiel langfristige Verträge mit Supermärkten abzuschließen.", "Однако ты можешь добровольно стать предпринимателем, чтобы, например, заключать долгосрочные договоры с супермаркетами."),
        new("Dadurch bekommst du die Rechte eines Kaufmanns, aber auch die Pflichten.", "Таким образом ты получаешь права предпринимателя, но и обязанности."),
        new("Eine der Pflichten ist die Buchführung über deine Einnahmen und Ausgaben, die dich viel Zeit kosten kann.", "Одной из обязанностей является ведение бухгалтерии доходов и расходов, что может отнимать много времени."),
        new("Denk also gut über diese Entscheidung nach.", "Поэтому хорошо подумай над этим решением."),
        new("Weiter geht es mit dem Fektiv-Kaufmann.", "Далее — Fiktiv‑Kaufmann."),
        new("Das ist jemand, der irrtümlich im Handelsregister eingetragen ist.", "Это тот, кто ошибочно внесён в торговый реестр."),
        new("Dabei meldest du etwa ein kleines Handwerksgewerbe an, das gar nicht groß genug für die Kaufmannseigenschaft ist.", "Например, ты регистрируешь небольшое ремесленное предприятие, которое недостаточно велико для статуса предпринимателя."),
        new("Trotzdem bist du jetzt im Handelsregister eingetragen.", "Тем не менее ты теперь внесён в торговый реестр."),
        new("Ab diesem Moment gelten für dich die gleichen Pflichten wie für alle anderen Kaufleute, auch wenn der Eintrag ein Fehler war.", "С этого момента для тебя действуют те же обязанности, что и для всех других предпринимателей, даже если запись была ошибочной."),
        new("Ein Scheinkaufmann hingegen tut nur so, als wäre er Kaufmann.", "Scheinkaufmann же лишь делает вид, что он предприниматель."),
        new("Als solcher betreibst du beispielsweise nur einen kleinen Stand auf dem Flohmarkt und gibst dich gegenüber anderen als großes Handelsunternehmen aus.", "Например, ты держишь лишь небольшой лоток на блошином рынке, но выдаёшь себя за крупное торговое предприятие."),
        new("Damit möchtest du Vorteile wie mehr Vertrauen oder bessere Vertragsbedingungen gewinnen.", "Тем самым ты хочешь получить преимущества, такие как больше доверия или лучшие условия договора."),
        new("Auch wenn das zunächst klug erscheint, könnte es später zu rechtlichen Problemen führen.", "Хотя сначала это кажется умным, позже это может привести к юридическим проблемам."),
        new("Egal welche Form des Kaufmanns du bist, du hast gewisse Rechte und Pflichten.", "Независимо от формы предпринимателя, у тебя есть определённые права и обязанности."),
        new("Als Kaufmann darfst du dir einen eigenen Unternehmensnamen aussuchen, der zu deinem Unternehmen passt.", "Как предприниматель ты можешь выбрать собственное название предприятия, которое подходит твоей фирме."),
        new("Mit deinem Namen kannst du dann offiziell Geschäfte machen und ihn vor Gericht nutzen, um zu klagen oder verklagt zu werden.", "Под своим названием ты можешь официально вести дела и использовать его в суде для подачи иска или как ответчик."),
        new("Außerdem kannst du deinen Mitarbeitern die sogenannte Prokura geben.", "Кроме того, ты можешь дать сотрудникам так называемую прокуру."),
        new("Das ist eine Vollmacht, die es der Person erlaubt, für dich und dein Unternehmen Entscheidungen zu treffen.", "Это полномочие, которое позволяет человеку принимать решения за тебя и твою компанию."),
        new("Natürlich hast du auch Pflichten.", "Конечно, у тебя есть и обязанности."),
        new("Du musst dich ins Handelsregister eintragen lassen und eine ordentliche Buchführung führen.", "Ты должен внести себя в торговый реестр и вести надлежащий бухгалтерский учёт."),
        new("Dabei dokumentierst du alle deine Einnahmen und Ausgaben.", "При этом ты фиксируешь все свои доходы и расходы."),
        new("Zudem musst du einen Jahresabschluss erstellen und wichtige Unterlagen wie Verträge und Rechnungen mehrere Jahre aufbewahren.", "Кроме того, ты должен составлять годовой отчёт и хранить важные документы, такие как договоры и счета, несколько лет."),
        new("Die Rechte und Pflichten sorgen dafür, dass du als Kaufmann professionell arbeiten und faire Geschäfte machen kannst.", "Права и обязанности обеспечивают, чтобы ты как предприниматель работал профессионально и заключал честные сделки."),
        new("Um nun herauszufinden, welche Kaufmannsform für dich am besten ist, solltest du sie dir noch einzeln anschauen.", "Чтобы понять, какая форма предпринимателя лучше всего подходит тебе, стоит рассмотреть их по отдельности."),
        new("Hier erfährst du mehr über den Formkaufmann.", "Здесь ты узнаешь больше о Form‑Kaufmann."),
    };

    public void OnGet() { }
}
