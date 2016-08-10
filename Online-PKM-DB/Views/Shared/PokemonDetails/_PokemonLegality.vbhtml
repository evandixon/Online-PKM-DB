@ModelType Online_PKM_DB.ViewModels.PK6ViewModel
<div>
    <a id="legality-report"></a>
    <h4>Legality</h4>
    <hr />
    <p>@Html.Raw(Server.HtmlEncode(Model.LegalityReport).Replace(vbLf, "<br />"))</p>
</div>
