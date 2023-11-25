import { useEffect, useState } from 'react';
import axios from 'axios';
import './home.css';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const Home = () => {
  const [entryData, setEntryData] = useState('');
  const [token, setToken] = useState('');

  useEffect(() => {
    const interval = setInterval(() => {
      axios.get('https://localhost:7038/resources/Resources/GetAllResources')
      .then((response) => {
        console.log(response.data);
        setEntryData(response.data);
      })
    }, 10000);
    return () => clearInterval(interval);
  });

  const handleToken = (e) => {
    setToken(e.target.value);
  };

  const handleDelete = () => {
    axios.delete('https://localhost:7038/resources/Resources/DeleteResources', {
      headers: {
        'Accept': 'text/plain',
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + token
      }
    })
    .then(response => {
      toast.success(response.data);
      console.log(response);
    });

    setToken('');
  }

  return (
    <div>
      <h1>All entries</h1>

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
          {entryData ? (entryData.map(item => (
            <tr key={item.rName}>
              <td>{item.rName}</td>
              <td>{item.rUrl}</td>
              <td>{item.compName}</td>
              <td>{item.pName}</td>
              <td>{item.cName}</td>
              <td>{item.lDescription}</td>
            </tr>
          ))) : (<tr></tr>)}
        </tbody>
      </table>

      <label className="label">Token</label>
      <input onChange={handleToken} className="input" value={token} type="text" />
      <button onClick={handleDelete} className="btn" type="submit">Delete all</button>

      <ToastContainer />
    </div>
  );
};
  
export default Home;