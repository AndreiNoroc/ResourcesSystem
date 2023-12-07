import 'react-toastify/dist/ReactToastify.css';
import { ToastContainer, toast } from 'react-toastify';
import { useEffect, useState } from 'react';
import axios from 'axios';
import Cookies from 'universal-cookie';

const Admin = () => {
    const [entryData, setEntryData] = useState([]);
    const cookie = new Cookies();
    let token = cookie.get('token');

    useEffect(() => {
        const interval = setInterval(() => {
          axios.get('https://localhost:7038/api/Admin/GetAllUsers', {
            headers: {
              'Accept': 'text/plain',
              'Content-Type': 'application/json',
              'Authorization': 'Bearer ' + token
            }
          })
          .then((response) => {
            console.log(response.data);
            setEntryData(response.data);
          })
          .catch((error) => {
            console.error('Error fetching data:', error.message);
            // Handle the error as needed
          });
        }, 1000);
        return () => clearInterval(interval);
      });

    const [uname, setName] = useState('');
    const [pass, setPassword] = useState('');
    const [crole, setCRole] = useState('');

    const handleUsername = (e) => {
        setName(e.target.value);
      };
     
      const handlePassword = (e) => {
        setPassword(e.target.value);
      };
    
      const handleRole = (e) => {
        setCRole(e.target.value);
      };

      const handleSubmit = async () => {
        if (uname === '' || pass === '' || crole === '') {
          toast.error("Wrong credentials");
        } else {
          const data = {"username": uname, "password": pass, "role": crole};
          const res = await axios.post("https://localhost:7038/api/Admin/InsertUser", data, {
            headers: {
              'Accept': 'text/plain',
              'Content-Type': 'application/json',
              'Authorization': 'Bearer ' + token
            }
          });
    
          if (res.status === 200) {
            toast.success(res.data);
          }
    
          setName('');
          setPassword('');
          setCRole('');
    
          console.log(res);
        }
      };

      const [username, setUserName] = useState('');
      const handleUsername2 = (e) => {
        setUserName(e.target.value);
      };
      const handleSubmit2 = async () => {
        if (username === '') {
          toast.error("Wrong credentials");
        } else {
          const url = 'https://localhost:7038/api/Admin/DeleteUser?username=' + username;
          const res = await axios.delete(url, {
            headers: {
              'Accept': 'application/json',
              'Content-Type': 'application/json',
              'Authorization': 'Bearer ' + token
            }
          });
    
          if (res.status === 200) {
            toast.success(res.data);
          }
          setUserName('');
    
          console.log(res);
        }
      };

    return (
        <div>
        <div>
            <h1>Admin page</h1>
        </div>
        <div>
            <h2>All users</h2>
        <table>
            <thead>
            <tr>
                <th>Name</th>
            </tr>
            </thead>
            <ul>
                {entryData.map((name, index) => (
                <li key={index}>{name}</li>
                ))}
            </ul>
        </table>
        </div>
        <div>
            <h2>Insert user</h2>
            <div>
                <form>
                {/* Labels and inputs for form data */}
                <label className="label">Username</label>
                <input onChange={handleUsername} className="input"
                    value={uname} type="text" />
                <label className="label">Password</label>
                <input onChange={handlePassword} className="input"
                    value={pass} type="password" />

                <label className="label">Role</label>
                <input onChange={handleRole} className="input"
                    value={crole} type="text" />
                </form>

                <button onClick={handleSubmit} className="btn" type="submit">
                    Submit
                </button>
            </div>
        </div>
        <div>
            <h2>Delete user</h2>
            <div>
                <form>
                    {/* Labels and inputs for form data */}
                    <label className="label">Username</label>
                    <input onChange={handleUsername2} className="input"
                        value={username} type="text" />
                </form>
                <button onClick={handleSubmit2} className="btn" type="submit">
                    Submit
                </button>
            </div>
        </div>
        <ToastContainer />
        </div>
    );
};

export default Admin;