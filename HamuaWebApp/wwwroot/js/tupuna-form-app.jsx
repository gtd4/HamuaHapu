//let count = 2;

class TupunaForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = { ngaTupuna: [] };
        this.addTupuna = this.addTupuna.bind(this);
        this.removeTupuna = this.removeTupuna.bind(this);
    }

    addTupuna(e) {
        e.preventDefault();
        const ngaTupuna = this.state.ngaTupuna;
        this.setState({
            ngaTupuna: ngaTupuna.concat(<TupunaFormComponent key={ngaTupuna.length} index={ngaTupuna.length + 2} removeTupuna={this.removeTupuna} />)
        });
    }

    removeTupuna(e, itemId) {
        //e.preventDefault();
        //const ngaTupuna = this.state.ngaTupuna;
        //this.setState({
        //    ngaTupuna: ngaTupuna.slice(<TupunaFormComponent key={ngaTupuna.length} index={ngaTupuna.length} />)
        //});
        e.preventDefault();

        const ngaTupuna = this.state.ngaTupuna.filter(item => item.props.index !== itemId);
        this.setState({ ngaTupuna: ngaTupuna });
    }

    render() {
        return (
            <div className="tupuna-container">
                <h2>Add Tupuna</h2>
                {this.state.ngaTupuna.map(function (TupunaFormComponent, index) {
                    return TupunaFormComponent;
                })}
                <hr />
                <button onClick={this.addTupuna} className="add-tupuna-button">Add {this.state.ngaTupuna.length + 1}</button>

            </div>);
    }
}

////////////////////////////////////////////////////////

class TupunaFormComponent extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            Name: null, PrimaryIwi: null, PrimaryHapu: null, Relationship: null
        };
        this.handleChange = this.handleChange.bind(this);
    }
    handleChange(event) {
        this.setState({ Relationship: event.target.value });
    }

    render() {
        return (
            <div>
                <button className="remove-tupuna-btn" onClick={(e) => this.props.removeTupuna(e, this.props.index)}>Remove {this.props.index}</button>
                <hr />
                <div className="form-group">
                    <label className="control-label">Tupuna Name</label>
                    <input name={"Member.NgaTupuna[" + this.props.index + "].Name"} id={"Member.NgaTupuna[" + this.props.index + "].Name"} type="text" className="form-control tupuna-control" />
                    
                    <span className="text-danger" />
                </div>
                <div className="form-group">
                    <label className="control-label">Tupuna Primary Iwi</label>
                    <input name={"Member.NgaTupuna[" + this.props.index + "].PrimaryIwi"} id={" Member.NgaTupuna[" + this.props.index + "].PrimaryIwi"} type="text" className="form-control tupuna-control" />
                    
                    <span className="text-danger" />
                </div>
                <div className="form-group">
                    <label className="control-label">Tupuna Primary Hapū</label>
                    <input name={"Member.NgaTupuna[" + this.props.index + "].PrimaryHapu"} id={"Member.NgaTupuna[" + this.props.index + "].PrimaryHapu"} type="text" className="form-control tupuna-control" />
                    
                    <span className="text-danger" />
                </div>
                <div className="form-group">
                    <label className="control-label" />
                    <select defaultValue={"Relationship"} name={"Member.NgaTupuna[" + this.props.index + "].Relationship"} id={"Member.NgaTupuna[" + this.props.index + "].Relationship"} className="form-control">
                    
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

ReactDOM.render(<TupunaForm />, document.getElementById('react-tupuna'));