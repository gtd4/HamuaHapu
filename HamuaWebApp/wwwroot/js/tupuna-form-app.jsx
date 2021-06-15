//let count = 2;
//var data = [
//    { Name: 'Mum', PrimaryIwi: 'abc', PrimaryHapu: "bvc", Relationship: "Mother" },
//    { Name: 'Dad', PrimaryIwi: 'abc', PrimaryHapu: "bvc", Relationship: "Father" },
//    { Name: 'Gav', PrimaryIwi: 'abc', PrimaryHapu: "bvc", Relationship: "GrandFather (MothersSide)" },
//    { Name: 'koro', PrimaryIwi: 'abc', PrimaryHapu: "bvc", Relationship: "GrandFather (FathersSide)" },
//    { Name: 'Nan', PrimaryIwi: 'abc', PrimaryHapu: "bvc", Relationship: "GrandMother (MothersSide)" },
//    { Name: 'Big Nan', PrimaryIwi: 'abc', PrimaryHapu: "bvc", Relationship: "GrandMother (FathersSide)" }
//];

class TupunaForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = { ngaTupuna: [] };
        this.addTupuna = this.addTupuna.bind(this);
        this.removeTupuna = this.removeTupuna.bind(this);
    }
    componentDidMount() {
        this.populateTupuna(this.props.data);
    }
    populateTupuna(savedTupuna) {
        var ngaTupuna = this.state.ngaTupuna;
        var tupunaArray = [];
        for (var i = 2; i < savedTupuna.length; i++) {
            var tupuna = savedTupuna[i];

            var component = <TupunaFormComponent key={tupunaArray.length} index={tupunaArray.length + 2} name={tupuna.Name} primaryIwi={tupuna.PrimaryIwi} primaryHapu={tupuna.PrimaryHapu} relationship={tupuna.Relationship} removeTupuna={this.removeTupuna} />
            tupunaArray.push(component);
        }

        this.setState({
            ngaTupuna: tupunaArray
        });
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
                <button onClick={this.addTupuna} className="add-tupuna-button btn btn-dark">+</button>

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
        this.onInputchange = this.onInputchange.bind(this);
    }
    handleChange(event) {
        this.setState({ Relationship: event.target.value });
    }
    onInputchange(event) {
        this.setState({
            [event.target.name]: event.target.value
        });
    }

    render() {
        return (
            <div>
                <button className="remove-tupuna-btn btn btn-danger" onClick={(e) => this.props.removeTupuna(e, this.props.index)}>-</button>
                <hr />
                <div className="form-group">
                    <label className="control-label">Tupuna Name</label>
                    <input name={"Member.NgaTupuna[" + this.props.index + "].Name"} id={"Member.NgaTupuna[" + this.props.index + "].Name"} type="text" className="form-control tupuna-control" onChange={this.onInputchange} value={this.props.name} />

                    <span className="text-danger" />
                </div>
                <div className="form-group">
                    <label className="control-label">Tupuna Primary Iwi</label>
                    <input name={"Member.NgaTupuna[" + this.props.index + "].PrimaryIwi"} id={" Member.NgaTupuna[" + this.props.index + "].PrimaryIwi"} type="text" onChange={this.onInputchange} value={this.props.primaryIwi} className="form-control tupuna-control" />

                    <span className="text-danger" />
                </div>
                <div className="form-group">
                    <label className="control-label">Tupuna Primary Hapū</label>
                    <input name={"Member.NgaTupuna[" + this.props.index + "].PrimaryHapu"} id={"Member.NgaTupuna[" + this.props.index + "].PrimaryHapu"} type="text" onChange={this.onInputchange} value={this.props.primaryHapu} className="form-control tupuna-control" />

                    <span className="text-danger" />
                </div>
                <div className="form-group">
                    <label className="control-label" />
                    <select defaultValue={this.props.relationship} name={"Member.NgaTupuna[" + this.props.index + "].Relationship"} id={"Member.NgaTupuna[" + this.props.index + "].Relationship"} className="form-control">

                        <option value={"Relationship"}>Relationship</option>
                        <option value={"GrandMother (Mothers Side)"}>GrandMother (Mothers Side)</option>
                        <option value={"GrandFather (Mothers Side)"}>GrandFather (Mothers Side)</option>
                        <option value={"GrandMother (Fathers Side)"}>GrandMother (Fathers Side)</option>
                        <option value={"GrandFather (Fathers Side)"}>GrandFather (Fathers Side)</option>
                    </select>
                    <span className="text-danger" />
                </div>
            </div >);
    }
}

//ReactDOM.render(<TupunaForm data={data} />, document.getElementById('react-tupuna'));