/// <reference path="utils/api.js" />
import React, { Component, useState, useEffect } from "react";
import API from "./utils/API";
import axios from 'axios'


export default () => {
    const [state, setState] = useState({
        student: {},
        students: [],
        Name: ""
    });

    useEffect(() => {
        API.getStudents().then(resp => {
            console.log(resp.data)
            setState(state => ({ ...state, students: resp.data }))
        });

        API.getStudentByDegreeId(1).then(data => console.log(data))

        //axios.get('api/roster')
        //    .then(data => console.log(data.data.result))
    }, []);

    const updateForm = ({ target }) =>
        setState({
            ...state,
            [target.name]: target.value
        });

    const submit = () => {
        API.postStudent({ Name: state.Name }).then(resp =>
            setState({
                ...state,
                Name: '',
                students: [...state.students, resp.data]
            })
        );
    };

    const deleteStudent = id => {
        API.deleteStudent(id).then(resp =>
            setState({
                ...state,
                student: resp.data,
                students: state.students.filter(stud => stud.student_id !== id)
            })
        );
    };

    const selectStudent = id => {
        API.getStudent(id).then(resp =>
            setState({
                ...state,
                student: resp.data
            })
        );
    };

    const edit = () => {
        API.putStudent({...state.student, first_name: state.Name })
            .then(resp => 
                setState({
                    ...state,
                    student: resp.data,
                    students: state.students.map(s => s.student_id === state.student.student_id ? resp.data : s)
                })
            )
    }

    return (
        <>
            <h1>
                Hello: {Object.keys(state.student).length
                    ? state.student.first_name + " " + state.student.last_name
                    : "Visitor"}
            </h1>

            {
                state.student.first_name && <>
                    <input type="text" name="Name" value={state.Name} onChange={updateForm} />
                    <button onClick={edit}>Edit</button>
                    </>
            }

            <hr />

            <input type="text" name="Name" value={state.Name} onChange={updateForm} />
            <br />
            <button onClick={submit}>Add</button>

            <hr />

            {state.students.map((stud, i) => (
                <div key={i + "-student"}>
                    <h4 onClick={() => selectStudent(stud.student_id)}>{stud.first_name}</h4>

                    <button onClick={() => deleteStudent(stud.student_id)}>X</button>
                </div>
            ))}
        </>
    );
};
