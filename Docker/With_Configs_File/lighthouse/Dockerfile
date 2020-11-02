# Set Phoesion Glow Lighthouse image as base
FROM phoesion/phoesion.glow.lighthouse:latest

# Create configs dir
RUN mkdir -p /etc/phoesion/glow/lighthouse

# COPY configs.json to etc
COPY configs.json /etc/phoesion/glow/lighthouse/configs.json