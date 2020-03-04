import axios from 'axios';

export default {
    getStudents: () => axios.get('api/student'),
    getStudent: id => axios.get('api/student/' + id),
    postStudent: data => axios.post('api/student', data),
    putStudent: (id, data) => axios.put('api/student/' + id, data),
    deleteStudent: id => axios.delete('api/student/' + id)
}