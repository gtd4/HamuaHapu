//let count = 2;

class TupunaFormComponent extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div>
                <btn className="remove-tupuna-btn">Remove</btn>
                <div className="form-group">
                    <label className="control-label">Tupuna Name</label>
                    <input name="Member.NgaTupuna[{this.props.index}].Name" id="Member.NgaTupuna[{this.props.index}].Name" asp-for="@Model.Member.NgaTupuna.ElementAt({this.props.index}).Name" type="text" className="form-control tupuna-control" />
                    <span className="text-danger" />
                </div>
                <div className="form-group">
                    <label className="control-label">Tupuna Primary Iwi</label>
                    <input name="Member.NgaTupuna[{this.props.index}].PrimaryIwi" id="Member.NgaTupuna[{this.props.index}].PrimaryIwi" asp-for="@Model.Member.NgaTupuna.ElementAt({this.props.index}).PrimaryIwi" type="text" className="form-control tupuna-control" />
                    <span className="text-danger" />
                </div>
                <div className="form-group">
                    <label className="control-label">Tupuna Primary Hapū</label>
                    <input name="Member.NgaTupuna[{this.props.index}].PrimaryHapu" id="Member.NgaTupuna[{this.props.index}].PrimaryHapu" asp-for="@Model.Member.NgaTupuna.ElementAt({this.props.index}).PrimaryHapu" type="text" className="form-control tupuna-control" />
                    <span className="text-danger" />
                </div>
                <div className="form-group">
                    <label className="control-label" />
                    <select name="Member.NgaTupuna[{this.props.index}].Relationship" id="Member.NgaTupuna[@i].Relationship" asp-for="@Model.Member.NgaTupuna.ElementAt({this.props.index}).Relationship" type="text" className="form-control" value="@relationship">
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