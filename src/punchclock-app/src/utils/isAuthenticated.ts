const isAuthenticated = () => {
  const expirationString = localStorage.getItem('expiration');
  if (!expirationString) {
    return false;
  }
  const expiration = new Date(expirationString);
  if (expiration < new Date()) {
    return false;
  }
  const token = localStorage.getItem('token');
  if (!token) {
    return false;
  }
  return true;
};

export default isAuthenticated;
