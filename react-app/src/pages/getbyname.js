import { useState } from 'react';
import axios from 'axios';
import './home.css';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const GetByName = () => {
    const [entryData, setEntryData] = useState('');
    const [rname, setRName] = useState('');
    const [token, setToken] = useState('');

    const handleResourceName = (e) => {
        setRName(e.target.value);
    };

    const handleToken = (e) => {
        setToken(e.target.value);
    };

    const handleSubmit = () => {
        axios.get('https://localhost:7038/resources/Resources/GetByName/' + rname, {
            headers: {
              'Authorization': 'Bearer ' + token,
              'Content-Type': 'application/json'
            }
          })
        .then((response) => {
            console.log(response.data);
            setEntryData(response.data);
        });
    };

    return (
        <div>
        <h1>All entries</h1>

        <label className="label">Resource name</label>
        <input onChange={handleResourceName} className="input" value={rname} type="text" />

        <label className="label">Token</label>
        <input onChange={handleToken} className="input" value={token} type="text" />

        <button onClick={handleSubmit} className="btn" type="submit">Submit</button>
 
        <table>
            <thead>
            <tr>
                <th>Resource Name</th>
                <th>Link</th>
                <th>Company</th>
                <th>Position</th>
                <th>Category</th>
                <th>Description</th>
            </tr>
            </thead>
            <tbody>
                <tr key={entryData.rName}>
                <td>{entryData.rName}</td>
                <td>{entryData.rUrl}</td>
                <td>{entryData.compName}</td>
                <td>{entryData.pName}</td>
                <td>{entryData.cName}</td>
                <td>{entryData.lDescription}</td>
                </tr>
            </tbody>
        </table>

        <ToastContainer />
        </div>
    );
};

export default GetByName;