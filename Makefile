dev-up:
	docker compose -f docker-compose-dev.yml up -d --build

dev-down:
	docker compose -f docker-compose-dev.yml down

dev-logs:
	docker compose -f docker-compose-dev.yml logs -f