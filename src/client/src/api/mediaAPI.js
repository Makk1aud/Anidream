import axios from "axios";
import { resolvePath } from "react-router-dom";

const API_BASE_URL = "http://localhost:5001/api";

export const fetchMediaList = async () => {
  const response = await axios.get(`${API_BASE_URL}/media`);

  return response.data;
};

export const fetchMediaById = async (mediaId) => {
  const response = await axios.get(`${API_BASE_URL}/media/${mediaId}`)

  return response.data;
};

export const fetchMediaImage = (alias) => {
  return `${API_BASE_URL}/Storage/media/image/${alias}`;
}

export const fetchSeriesByNum = (alias, num) => {
  return `${API_BASE_URL}/Storage/media/video/${alias}/episode/${num}`
}
