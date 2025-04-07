const { PrismaClient } = require("@prisma/client");
const prisma = new PrismaClient();

const getAlldiak = async (req, res) => {
    try {
      const lekeres = await prisma.diak.findMany({
        include: {
            verseny: true,
            verseny_id: false,
        },
      });
      res.json(lekeres);
    } catch (error) {
        console.error(error);
        res.status(400).json({ error: "Hiba történt a felhasználó létrehozásakor." });
    }
  };

  const postDiak = async (req, res) => {
    try {
      const { nev, iskola, verseny_id } = req.body;
      const newDiak = await prisma.diak.create({
        data: {
            nev,
            iskola,
            verseny_id: parseInt(verseny_id),
        }
      });
      res.json(newDiak);
    } catch (error) {
        console.error(error);
        res.status(500).json({ error: "Hiba történt a felhasználó létrehozásakor." });
    }
}


module.exports = {
    getAlldiak,
    postDiak,
  };