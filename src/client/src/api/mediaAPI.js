import axios from "axios";
import { resolvePath } from "react-router-dom";

const API_BASE_URL = "http://localhost:5001/api";

export const fetchMediaList = async () => {
  const response = await axios.get(`${API_BASE_URL}/media`);

  return response.data;
};

export const fetchMediaById = async () => {
  const response = await axios.get(`${API_BASE_URL}/media`)
};

export const fetchMediaImage = (alias) => {
  return `${API_BASE_URL}/Storage/media/image/${alias}`;
}


