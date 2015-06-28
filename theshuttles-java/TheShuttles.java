public class TheShuttles {

	public int getLeastCost(int[] cnt, int baseCost, int seatCost) {

		int minShuttlesCount = cnt.length;
		int bestFullCost = Integer.MAX_VALUE;

		int employeesCount = 0;
		for (int i = 0; i < cnt.length; i++) {
			employeesCount += cnt[i];
		}

		for (int shuttleCount = minShuttlesCount; shuttleCount < 100; shuttleCount++) {
			for (int seatCount = 1; seatCount < 100; seatCount++) {
				// int shuttlesNeeded = (int)((double)employeesCount /
				// (double)(i * seatCount));
				// if((double)employeesCount / (double)(i * seatCount) != 1)
				// shuttlesNeeded++;
				//
				// if(shuttlesNeeded < minShuttlesCount)
				// shuttlesNeeded = minShuttlesCount;

				if (shuttleCount * seatCount >= employeesCount) {

					int shuttleNeeded = 0;
					for (int i = 0; i < cnt.length; i++) {
						shuttleNeeded += Math.ceil((double) cnt[i]
								/ (double) seatCount);
					}

					if (shuttleNeeded <= shuttleCount) {
						int cost = (shuttleCount * baseCost)
								+ (shuttleCount * (seatCount * seatCost));

						if (bestFullCost > cost)
							bestFullCost = cost;
					}
				}
			}
		}

		return bestFullCost;
	}

}
