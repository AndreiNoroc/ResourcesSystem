import './App.css';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import Navbar from './components/NavBar';
import Home from './pages/home';
import SignUp from './pages/signup';
import SignIn from './pages/signin';
import GetByName from './pages/getbyname';
import AddResource from './pages/addresource';
import UpdateResource from './pages/updateresource';

function App() {
  return (
    <Router>
      <Navbar />
      <Routes>
        <Route path='/' index Component={Home} />
        <Route path='/getbyname' Component={GetByName} />
        <Route path='/sign-up' Component={SignUp} />
        <Route path='/addresource' Component={AddResource} />
        <Route path='/updateresource' Component={UpdateResource} />
        <Route path='/signin' Component={SignIn} />
      </Routes>
      <ToastContainer />
    </Router>
  );
}

export default App;
