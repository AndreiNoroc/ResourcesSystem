import { useState } from 'react';
import axios from 'axios';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
  
const SignUp = () => {
  const [uname, setName] = useState('');
  const [pass, setPassword] = useState('');
  const [cpass, setCPassword] = useState('');
 
  const handleUsername = (e) => {
    setName(e.target.value);
  };
 
  const handlePassword = (e) => {
    setPassword(e.target.value);
  };

  const handleConfirmPassword = (e) => {
    setCPassword(e.target.value);
  };
 
  const handleSubmit = async () => {
    if (uname === '' || pass === '' || pass !== cpass) {
      toast.error("Wrong credentials");
    } else {
      const data = {"username": uname, "password": pass};
      const res = await axios.post("https://localhost:7038/api/User/register", data, {
        headers: {
          'Accept': 'text/plain',
          'Content-Type': 'application/json'
        }
      });

      if (res.status === 200) {
        toast.success(res.data);
      }

      setName('');
      setPassword('');
      setCPassword('');

      console.log(res);
    }
  };
  
  return (
    <div>
      <div>
        <h1>Sign Up</h1>
      </div>
      <div>
        <form>
          {/* Labels and inputs for form data */}
          <label className="label">Username</label>
          <input onChange={handleUsername} className="input"
            value={uname} type="text" />
  
          <label className="label">Password</label>
          <input onChange={handlePassword} className="input"
            value={pass} type="password" />

          <label className="label">Confirm Password</label>
          <input onChange={handleConfirmPassword} className="input"
            value={cpass} type="password" />
        </form>

        <button onClick={handleSubmit} className="btn" type="submit">
            Submit
          </button>
      </div>
      <ToastContainer />
    </div>
  );
};
  
export default SignUp;