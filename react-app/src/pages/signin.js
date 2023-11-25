import { useState } from 'react';
import axios from 'axios';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { useNavigate } from 'react-router-dom';

const SignIn = () => {
  const [uname, setName] = useState('');
  const [pass, setPassword] = useState('');
  const navigate = useNavigate();

  const handleUsername = (e) => {
    setName(e.target.value);
  };
 
  const handlePassword = (e) => {
    setPassword(e.target.value);
  };
 
  const handleSubmit = async () => {
    if (uname === '' || pass === '') {
      toast.error("Wrong credentials");
    } else {
      const data = {"username": uname, "password": pass};
      const res = await axios.post("https://localhost:7038/api/User/login", data, {
        headers: {
          'Accept': 'text/plain',
          'Content-Type': 'application/json'
        }
      });

      if (res.status === 200) {
        toast.success("Successfully logged in! Your token is \n" + res.data);
        navigate('/');
      }

      console.log(res);
    }
  };
  
  return (
    <div>
      <div>
        <h1>Sign In</h1>
      </div>
      <div>
        <form>
          <label className="label">Username</label>
          <input onChange={handleUsername} className="input"
            value={uname} type="text" />
  
          <label className="label">Password</label>
          <input onChange={handlePassword} className="input"
            value={pass} type="password" />
        </form>

        <button onClick={handleSubmit} className="btn" type="submit">
            Submit
        </button>
      </div>
      <ToastContainer />
    </div>
  );
};
  
export default SignIn;