import { useState } from 'react';
import axios from 'axios';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const UpdateResource = () => {
    const [findrname, setFindRname] = useState('');
    const [rname, setRname] = useState('');
    const [link, setLink] = useState('');
    const [company, setCompany] = useState('');
    const [position, setPosition] = useState('');
    const [category, setCategory] = useState('');
    const [description, setDescription] = useState('');
    const [token, setToken] = useState('');

    const handleFindRname = (e) => {
        setFindRname(e.target.value);
    }

    const handleRname = (e) => {
        setRname(e.target.value);
    }

    const handleLink = (e) => {
        setLink(e.target.value);
    }

    const handleCompany = (e) => {
        setCompany(e.target.value);
    }

    const handlePosition = (e) => {
        setPosition(e.target.value);
    }

    const handleCategory = (e) => {
        setCategory(e.target.value);
    }

    const handleDescription = (e) => {
        setDescription(e.target.value);
    }

    const handleToken = (e) => {
        setToken(e.target.value);
    };

    const handleSubmit = async () => {
          const data = {
            "cName": category, 
            "compName": company,
            "lDescription": description,
            "pName": position,
            "rName": rname,
            "rUrl": link
        };

          const res = await axios.put("https://localhost:7038/resources/Resources/InsertResource", data, {
            headers: {
              'Accept': 'text/plain',
              'Content-Type': 'application/json',
              'Authorization': 'Bearer ' + token
            }
          });
    
          if (res.status === 200) {
            toast.success(res.data);
            setRname('');
            setCategory('');
            setDescription('');
            setLink('');
            setPosition('');
            setCompany('');
            setToken('');
          }
    
          console.log(res);
      };

    return (
        <div>
      <div>
        <h1>Insert Resource</h1>
      </div>
      <div>
          <label className="label">Find Resource Name</label>
          <input onChange={handleFindRname} className="input"
            value={findrname} type="text" />

          <label className="label">Resource Name</label>
          <input onChange={handleRname} className="input"
            value={rname} type="text" />
  
          <label className="label">Link</label>
          <input onChange={handleLink} className="input"
            value={link} type="text" />

          <label className="label">Company</label>
          <input onChange={handleCompany} className="input"
            value={company} type="text" />
            
          <label className="label">Position</label>
          <input onChange={handlePosition} className="input"
            value={position} type="text" />

          <label className="label">Category</label>
          <input onChange={handleCategory} className="input"
            value={category} type="text" />
          <br></br>
          <label className="label">Description</label>
          <input onChange={handleDescription} className="input"
            value={description} type="text" />

          <label className="label">Token</label>
          <input onChange={handleToken} className="input" value={token} type="text" />

        <button onClick={handleSubmit} className="btn" type="submit">
            Submit
        </button>
      </div>
      <ToastContainer />
    </div>
    );
}

export default UpdateResource;