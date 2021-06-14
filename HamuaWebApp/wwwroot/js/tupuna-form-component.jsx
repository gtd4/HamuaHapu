//let count = 2;

class TupunaFormComponent extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            Name: null, PrimaryIwi: null, PrimaryHapu: null, Relationship: null
        };
    }

    render() {
        return (
            <div>
                <button className="remove-tupuna-btn" onClick={(e) => this.props.removeTupuna(e, this.props.index)}>Remove {this.props.index}</button>
                <hr />
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
                    <select defaultValue={"Relationship"} name="Member.NgaTupuna[{this.props.index}].Relationship" id="Member.NgaTupuna[@i].Relationship" asp-for="@Model.Member.NgaTupuna.ElementAt({this.props.index}).Relationship" type="text" className="form-control" value="@relationship">
                        <option value={"Relationship"}>Relationship</option>
                        <option value={"GrandMother (Mothers Side)"}>GrandMother (Mothers Side)</option>
                        <option value={"GrandFather (Mothers Side)"}>GrandFather (Mothers Side)</option>
                        <option value={"GrandMother (Fathers Side)"}>GrandMother (Fathers Side)</option>
                        <option value={"GrandFather (Fathers Side)"}>GrandFather (Fathers Side)</option>
                    </select>
                    <span className="text-danger" />
                </div>
            </div>);
    }
}

export default TupunaFormComponent;

//ReactDOM.render(<TupunaForm />, document.getElementById('react-tupuna'));