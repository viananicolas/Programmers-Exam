import axios from "axios";
const instance = axios.create({
  baseURL: `api/`,
  timeout: 10000
});

export const handleSubmit = async (event) => {
  event.preventDefault();
  const data = new FormData(event.target);
  let object = {};
  data.forEach(function(value, key) {
    object[key] = value;
  });
  console.log(object);
  let result = await instance.post("home", object);
  return result;
};

export const getPlays = async () => {
  const result = await instance.get(`home`);
  return result.data;
};
