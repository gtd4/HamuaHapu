'use strict';

const e = React.createElement;

class TupunaForm extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return <h2>I am a Car!</h2>;
        //<div class="form-group">
        //    <label class="control-label">@relationship's Name</label>
        //    <input name="Member.NgaTupuna[@i].Name" id="Member.NgaTupuna[@i].Name" asp-for="@Model.Member.NgaTupuna.ElementAt(i).Name" type="text" class="form-control @relationship-control" />
        //    <span class="text-danger"></span>
        //</div>
        //<div class="form-group">
        //    <label class="control-label">@relationship's Primary Iwi</label>
        //    <input name="Member.NgaTupuna[@i].PrimaryIwi" id="Member.NgaTupuna[@i].PrimaryIwi" asp-for="@Model.Member.NgaTupuna.ElementAt(i).PrimaryIwi" type="text" class="form-control @relationship-control" />
        //    <span class="text-danger"></span>
        //</div>
        //<div class="form-group">
        //    <label class="control-label">@relationship's Primary Hapū</label>
        //    <input name="Member.NgaTupuna[@i].PrimaryHapu" id="Member.NgaTupuna[@i].PrimaryHapu" asp-for="@Model.Member.NgaTupuna.ElementAt(i).PrimaryHapu" type="text" class="form-control @relationship-control" />
        //    <span class="text-danger"></span>
        //</div>
        //<div class="form-group">
        //    <label class="control-label"></label>
        //    <input name="Member.NgaTupuna[@i].Relationship" id="Member.NgaTupuna[@i].Relationship" asp-for="@Model.Member.NgaTupuna.ElementAt(i).Relationship" type="hidden" class="form-control" value="@relationship" />
        //    <span class="text-danger"></span>
        //</div>;
    }
}

const domContainer = document.querySelector('#react-tupuna');
ReactDOM.render(e(TupunaForm), domContainer);