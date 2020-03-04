import React, { Component } from 'react';
import API from './utils/API'

export default class App extends Component {
    static displayName = App.name;

    state = {
        students: [],
        student: {},
        Name: ''
    }

    handleChange = ({ target }) => this.setState({ [target.name]: target.value })

    componentDidMount() {
        API.getStudents()
            .then(resp => this.setState({ students: resp.data }, () => console.log(this.state)))
    }

    submit = () => {
        API.postStudent({ Name: this.state.Name })
            .then(resp => this.setState({ student: resp.data, students: [...this.state.students, resp.data] }, () => console.log(this.state)))
    }

    delete = id => {
        API.deleteStudent(id)
            .then(resp => this.setState({ students: this.state.students.filter(stud => stud.id !== id) }))
    }

    selectStudent = id => {
        API.getStudent(id)
            .then(resp => this.setState({ student: resp.data }, () => console.log(this.state)))
    }

    render() {
        return <>
            <h1>Hello: {Object.keys(this.state.student).length ? this.state.student.name : "Visitor"}</h1>

            <hr />

            <input type="text" name="Name" value={this.state.Name} onChange={this.handleChange} />
            <br />
            <button onClick={this.submit}>Add</button>

            <hr />

            {
                this.state.students.map((stud, i) => <div key={i + '-student'}>
                    <h4 onClick={() => this.selectStudent(stud.id)}>{stud.name}</h4>

                    <button onClick={() => this.delete(stud.id)}>X</button>
                </div>)
            }


        </>
    }
}
