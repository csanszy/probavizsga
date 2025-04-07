const { PrismaClient } = require("@prisma/client");
const prisma = new PrismaClient();

const getAllverseny = async (req, res) => {
    try {
      const lekeres = await prisma.verseny.findMany();
      res.json(lekeres);
    } catch (error) {
        console.error(error);
        res.status(400).json({ error: "Hiba történt a felhasználó létrehozásakor." });
    }
  };

  const putVerseny = async (req, res) => {
    try {
        const { id } = req.params;
        const updateverseny = await prisma.verseny.update({
            where: {
                id: parseInt(id),
              },
              data: {
                datum: req.body.datum ? new Date(req.body.datum) : undefined,
              },
        });
        res.json(updateverseny);
    } catch (error) {
        console.log(error);
        res.status(500).json({ error: "Hiba történt a frissítés során." });
        
    }
}

  module.exports = {
    getAllverseny,
    putVerseny,
  };