//let count = 2;

class TupunaForm extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div>
                <div className="form-group">
                    <label className="control-label">Tupuna Name</label>
                    <input name="Member.NgaTupuna[@i].Name" id="Member.NgaTupuna[@i].Name" asp-for="@Model.Member.NgaTupuna.ElementAt(i).Name" type="text" className="form-control tupuna-control" />
                    <span className="text-danger" />
                </div>
                <div className="form-group">
                    <label className="control-label">Tupuna Primary Iwi</label>
                    <input name="Member.NgaTupuna[@i].PrimaryIwi" id="Member.NgaTupuna[@i].PrimaryIwi" asp-for="@Model.Member.NgaTupuna.ElementAt(i).PrimaryIwi" type="text" className="form-control tupuna-control" />
                    <span className="text-danger" />
                </div>
                <div className="form-group">
                    <label className="control-label">Tupuna Primary Hapū</label>
                    <input name="Member.NgaTupuna[@i].PrimaryHapu" id="Member.NgaTupuna[@i].PrimaryHapu" asp-for="@Model.Member.NgaTupuna.ElementAt(i).PrimaryHapu" type="text" className="form-control tupuna-control" />
                    <span className="text-danger" />
                </div>
                <div className="form-group">
                    <label className="control-label" />
                    <select name="Member.NgaTupuna[@i].Relationship" id="Member.NgaTupuna[@i].Relationship" asp-for="@Model.Member.NgaTupuna.ElementAt(i).Relationship" type="text" className="form-control" value="@relationship">
                        <option>Relationship</option>
                        <option>GrandMother (Mothers Side)</option>
                        <option>GrandFather (Mothers Side)</option>
                        <option>GrandMother (Fathers Side)</option>
                        <option>GrandMother (Fathers Side)</option>
                    </select>
                    <span className="text-danger" />
                </div>
            </div>);
    }
}

ReactDOM.render(<TupunaForm />, document.getElementById('react-tupuna'));