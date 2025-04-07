const express = require("express");
const bodyParser = require("body-parser");
const cors = require("cors");

const app = express();

const diak = require("./Routes/diakRoute");
const verseny = require("./Routes/versenyRoute")

const corsOptions = {
  origin: "http://localhost:3000",
  credentials: true,
};

app.use(express.json());
app.use(cors(corsOptions));
app.use(bodyParser.urlencoded({ extended: true }));
app.use("/api", diak);
app.use("/api", verseny)

app.listen(5500, () => {
  console.log("Started at http://localhost:5500");
});