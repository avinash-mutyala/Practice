import React, { Component } from 'react';

export class Add extends Component {

    constructor(props) {
        super(props);
        this.state = { FeildA: 0, FeildB: 0, Result: 0, Operator: 0 };
        this.handleChange = this.handleChange.bind(this);
        this.calculate = this.calculate.bind(this);
    }

    handleChange(e) {
        console.log(e.target.value === "");
        if (e.target.value === "" || e.target.value == null) {
            this.setState({
                [e.target.name]: ""
            });
        }else if (!isNaN(Number(e.target.value))) {
            this.setState({ [e.target.name]: Number(e.target.value) });
        }
        console.log(e.target.name + " " + e.target.value);
    }

    calculate() {
        console.log(this.state.FeildA + " " + this.state.FeildB);
        let value = this.state.Result;
        if (this.state.Operator === 0) {
            value = this.state.FeildA + this.state.FeildB;
        } else if (this.state.Operator === 1) {
            value = Math.abs(this.state.FeildA - this.state.FeildB);
        } else if (this.state.Operator === 2) {
            value = this.state.FeildA * this.state.FeildB;
        } else if (this.state.Operator === 3) {
            value = this.state.FeildA / this.state.FeildB;
        } else {
        }
        this.setState({ Result: value });
    }

    render() {
        const operators = [{ id: 0, value: "+" }, { id: 1, value: "-" }, { id: 2, value: "*" }, { id: 3, value: "/" }];

        return (
            <div>
                <h1>Addition</h1>

                <input type="text" name="FeildA" value={this.state.FeildA} onChange={(e) => this.handleChange(e)} />

                <span>  </span>
                <select name="Operator" value={this.state.Operator} onChange={(e) => this.handleChange(e)}>
                    {operators.map(op => (
                        <option key={op.id} value={op.id}>{op.value}</option>
                    ))}
                </select>
                <span>  </span>
                <input type="text" name="FeildB" value={this.state.FeildB} onChange={(e) => this.handleChange(e)} />
                <span> = {this.state.Result} </span>
                <br /><br />
                <p>
                    <button className="btn btn-primary" onClick={this.calculate}>Calculate</button>
                </p>
            </div>

        );
    }
}