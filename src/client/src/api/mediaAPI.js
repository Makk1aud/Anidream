import axios from "axios";
import { resolvePath } from "react-router-dom";

const API_BASE_URL = "http://localhost:5001/api/media";

export const fetchAnimeList = async () => {
  const response = await axios.get(API_BASE_URL);

  return response.data;
};

export const fetchAnimeById = async () => {
  const response = await axios.get(`${API_BASE_URL}/`)
}
