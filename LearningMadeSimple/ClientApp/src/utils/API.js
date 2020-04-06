import axios from 'axios';

export default {
    getStudents: () => axios.get('api/student'),
    getStudent: id => axios.get('api/student/' + id),
    getStudentByDegreeId: id => axios.get('api/student/GetByDegreeId/' + id),
    postStudent: data => axios.post('api/student', data),
    putStudent: (data) => axios.put('api/student', data),
    deleteStudent: id => axios.delete('api/student/' + id)
}